using Xunit;
using Xunit.Extensions;

namespace Voracek.Utils
{
    public class InterlockedBooleanTests
    {
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        public void InterlockedBooleanCanBeComparedWithAnotherInterlockedBoolean(bool a, bool b, bool result)
        {
            var interlockedA = InterlockedBoolean.Get(a);
            var interlockedB = InterlockedBoolean.Get(b);
            Assert.Equal<bool>(result, interlockedA == interlockedB);
            Assert.Equal<bool>(!result, interlockedA != interlockedB);
            Assert.Equal<bool>(result, interlockedA.Equals(interlockedB));
            Assert.Equal<bool>(result, interlockedA.Equals(b));
            Assert.Equal<bool>(result, a.Equals(interlockedB));
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        public void InterlockedBooleanCanBeComparedWithBoolean(bool a, bool b, bool result)
        {
            var interlockedA = InterlockedBoolean.Get(a);
            Assert.Equal<bool>(result, interlockedA == b);
            Assert.Equal<bool>(!result, interlockedA != b);
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        public void BooleanCanBeComparedWithInterlockedBoolean(bool a, bool b, bool result)
        {
            var interlockedB = InterlockedBoolean.Get(b);
            Assert.Equal<bool>(result, a == interlockedB);
            Assert.Equal<bool>(!result, a != interlockedB);
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(true, null, false)]
        [InlineData(false, null, false)]
        [InlineData(null, null, true)]
        public void InterlockedBooleanCanBeComparedWithNullableBoolean(bool? a, bool? b, bool result)
        {
            var interlockedA = InterlockedBoolean.Get(a);
            Assert.Equal<bool>(result, interlockedA == b);
            Assert.Equal<bool>(!result, interlockedA != b);
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(true, null, false)]
        [InlineData(false, null, false)]
        [InlineData(null, null, true)]
        public void NullableBooleanCanBeComparedWithInterlockedBoolean(bool? a, bool? b, bool result)
        {
            var interlockedB = InterlockedBoolean.Get(b);
            Assert.Equal<bool>(result, a == interlockedB);
            Assert.Equal<bool>(!result, a != interlockedB);
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, false, false)]
        public void InterlockedBooleanSupportsLogicalAnd(bool a, bool b, bool result)
        {
            var interlockedA = InterlockedBoolean.Get(a);
            var interlockedB= InterlockedBoolean.Get(b);
            Assert.Equal<bool>(result, interlockedA && interlockedB);
            Assert.Equal<bool>(result, a && interlockedB);
            Assert.Equal<bool>(result, interlockedA && b);
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, false, true)]
        [InlineData(false, true, true)]
        [InlineData(false, false, false)]
        public void InterlockedBooleanSupportsLogicalOr(bool a, bool b, bool result)
        {
            var interlockedA = InterlockedBoolean.Get(a);
            var interlockedB = InterlockedBoolean.Get(b);
            Assert.Equal<bool>(result, interlockedA || interlockedB);
            Assert.Equal<bool>(result, a || interlockedB);
            Assert.Equal<bool>(result, interlockedA || b);
        }

        [Theory]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(false, true, true)]
        [InlineData(false, false, false)]
        public void InterlockedBooleanSupportsLogicalXor(bool a, bool b, bool result)
        {
            var interlockedA = InterlockedBoolean.Get(a);
            var interlockedB = InterlockedBoolean.Get(b);
            Assert.Equal<bool>(result, interlockedA ^ interlockedB);
            Assert.Equal<bool>(result, a ^ interlockedB);
            Assert.Equal<bool>(result, interlockedA ^ b);
        }

        [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void InterlockedBooleanSupportsLogicalNot(bool a, bool result)
        {
            var interlockedA = InterlockedBoolean.Get(a);
            Assert.Equal<bool>(result, !interlockedA);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void InterlockedBooleanToStringEqualsBooleanToString(bool value)
        {
            Assert.Equal(value.ToString(), InterlockedBoolean.Get(value).ToString());
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void HashCodeOfTwoLogicalySameInterlockedBooleanVariablesIsSame(bool value)
        {
            var a = InterlockedBoolean.Get(value);
            var b = InterlockedBoolean.Get(value);
            Assert.Equal(a.GetHashCode(), b.GetHashCode());
        }
    }
}
