using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        /// <summary>
        ///     Returns the first failure from the supplied <paramref name="results"/>.
        ///     If there is no failure, a success result is returned.
        /// </summary>
        public static Result FirstFailureOrSuccess(params Result[] results)
            => FirstFailureOrSuccess(results as IEnumerable<Result>);

        /// <summary>
        ///     Returns the first failure from the supplied <paramref name="results"/>.
        ///     If there is no failure, a success result is returned.
        /// </summary>
        public static Result FirstFailureOrSuccess(IEnumerable<Result> results)
        {
            foreach (Result result in results)
            {
                if (result.IsFailure)
                    return result;
            }

            return Success();
        }

        /// <summary>
        ///     Returns the first failure from the supplied <paramref name="results"/>.
        ///     If there is no failure, a success result is returned.
        /// </summary>
        public static UnitResult<E> FirstFailureOrSuccess<E>(params UnitResult<E>[] results)
            => FirstFailureOrSuccess(results as IEnumerable<UnitResult<E>>);

        /// <summary>
        ///     Returns the first failure from the supplied <paramref name="results"/>.
        ///     If there is no failure, a success result is returned.
        /// </summary>
        public static UnitResult<E> FirstFailureOrSuccess<E>(IEnumerable<UnitResult<E>> results)
        {
            foreach (UnitResult<E> result in results)
            {
                if (result.IsFailure)
                    return result;
            }

            return UnitResult.Success<E>();
        }
    }
}
