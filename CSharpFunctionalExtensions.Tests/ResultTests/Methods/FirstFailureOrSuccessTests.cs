using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods
{
    public class FirstFailureOrSuccessTests : TestBase
    {
        [Fact]
        public void FirstFailureOrSuccess_returns_the_first_failed_result()
        {
            Result result1 = Result.Success();
            Result result2 = Result.Failure(ErrorMessage);
            Result result3 = Result.Failure(ErrorMessage + ErrorMessage);

            Result result = Result.FirstFailureOrSuccess(result1, result2, result3);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
            result.Should().Be(result2);
        }

        [Fact]
        public void FirstFailureOrSuccess_returns_success_if_no_failures()
        {
            Result result1 = Result.Success();
            Result result2 = Result.Success();
            Result result3 = Result.Success();

            Result result = Result.FirstFailureOrSuccess(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
            result.Should().Be(Result.Success());
        }

        [Fact]
        public void FirstFailureOrSuccess_ienumerable_returns_the_first_failed_result()
        {
            IEnumerable<Result> results = new Result[]
            {
                Result.Success(),
                Result.Failure(ErrorMessage),
                Result.Failure(ErrorMessage + ErrorMessage),
            };
            
            Result result = Result.FirstFailureOrSuccess(results);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(ErrorMessage);
            result.Should().Be(results.ElementAt(1));
        }

        [Fact]
        public void FirstFailureOrSuccess_ienumerable_returns_success_if_no_failures()
        {
            IEnumerable<Result> results = new Result[]
            {
                Result.Success(),
                Result.Success(),
                Result.Success(),
            };
            
            Result result = Result.FirstFailureOrSuccess(results);

            result.IsSuccess.Should().BeTrue();
            result.Should().Be(Result.Success());
        }

        [Fact]
        public void FirstFailureOrSuccess_unitresult_returns_the_first_failed_result()
        {
            UnitResult<E> result1 = UnitResult.Success<E>();
            Result<T, E> result2 = Result.Failure<T, E>(E.Value);
            Result<K, E> result3 = Result.Failure<K, E>(E.Value);

            UnitResult<E> result = Result.FirstFailureOrSuccess(result1, result2, result3);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact]
        public void FirstFailureOrSuccess_unitresult_returns_success_if_no_failures()
        {
            UnitResult<E> result1 = UnitResult.Success<E>();
            Result<T, E> result2 = Result.Success<T, E>(T.Value);
            Result<K, E> result3 = Result.Success<K, E>(K.Value);

            UnitResult<E> result = Result.FirstFailureOrSuccess(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
            result.Should().Be(UnitResult.Success<E>());
        }

        [Fact]
        public void FirstFailureOrSuccess_ienumerable_unitresult_returns_the_first_failed_result()
        {
            IEnumerable<UnitResult<E>> results = new UnitResult<E>[]
            {
                UnitResult.Success<E>(),
                Result.Failure<T, E>(E.Value),
                Result.Failure<K, E>(E.Value),
            };
            
            UnitResult<E> result = Result.FirstFailureOrSuccess(results);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(E.Value);
        }

        [Fact]
        public void FirstFailureOrSuccess_ienumerable_unitresult_returns_success_if_no_failures()
        {
            IEnumerable<UnitResult<E>> results = new UnitResult<E>[]
            {
                UnitResult.Success<E>(),
                Result.Success<T, E>(T.Value),
                Result.Success<K, E>(K.Value),
            };
            
            UnitResult<E> result = Result.FirstFailureOrSuccess(results);

            result.IsSuccess.Should().BeTrue();
            result.Should().Be(UnitResult.Success<E>());
        }
    }
}
