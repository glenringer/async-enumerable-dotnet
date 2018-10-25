using System;
using Xunit;
using async_enumerable_dotnet;
using System.Threading.Tasks;

namespace async_enumerable_dotnet_test
{
    public class RetryTest
    {
        [Fact]
        public async void Retry_Unlimited()
        {
            await AsyncEnumerable.Range(1, 2)
                .ConcatWith(AsyncEnumerable.Error<int>(new Exception()))
                .Retry()
                .Take(6)
                .AssertResult(1, 2, 1, 2, 1, 2);
        }

        [Fact]
        public async void Retry_Max()
        {
            await AsyncEnumerable.Range(1, 2)
                .ConcatWith(AsyncEnumerable.Error<int>(new InvalidOperationException()))
                .Retry(3)
                .AssertFailure(typeof(InvalidOperationException), 1, 2, 1, 2, 1, 2);
        }

        [Fact]
        public async void Retry_Condition()
        {
            await AsyncEnumerable.Range(1, 2)
                .ConcatWith(AsyncEnumerable.Error<int>(new InvalidOperationException()))
                .Retry((idx, ex) => idx < 2)
                .AssertFailure(typeof(InvalidOperationException), 1, 2, 1, 2, 1, 2);
        }
    }
}