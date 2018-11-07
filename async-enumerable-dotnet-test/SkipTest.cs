// Copyright (c) David Karnok & Contributors.
// Licensed under the Apache 2.0 License.
// See LICENSE file in the project root for full license information.

using Xunit;
using async_enumerable_dotnet;

namespace async_enumerable_dotnet_test
{
    public class SkipTest
    {
        [Fact]
        public async void Normal()
        {
            await AsyncEnumerable.Range(1, 10)
                .Skip(5)
                .AssertResult(6, 7, 8, 9, 10);
        }

        [Fact]
        public async void Zero()
        {
            await AsyncEnumerable.Range(1, 10)
                .Skip(0)
                .AssertResult(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
        }

        [Fact]
        public async void All()
        {
            await AsyncEnumerable.Range(1, 10)
                .Skip(10)
                .AssertResult();
        }
        
        [Fact]
        public async void More()
        {
            await AsyncEnumerable.Range(1, 10)
                .Skip(11)
                .AssertResult();
        }

    }
}
