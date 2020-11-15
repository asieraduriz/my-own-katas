using InitialProject;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class MyStackShould
    {
        private MyStack stack;

        [SetUp]
        public void SetUp()
        {
            stack = new MyStack();
        }

        [Test]
        public void 
        throw_exception_if_popped_when_empty()
        {
            Assert.Throws<EmptyStackException>(() => stack.Pop());
        }

        [Test]
        public void 
        pop_last_pushed_object()
        {
            var object1 = new object();
            stack.Push(object1);

            object poppedObject = stack.Pop();

            Assert.AreEqual(object1, poppedObject);
            
        }

        [Test]
        public void
        pop_in_reverse_push_order()
        {
            var object1 = new object();
            var object2 = new object();
            stack.Push(object1);
            stack.Push(object2);

            object poppedObject2 = stack.Pop();
            object poppedObject1 = stack.Pop();

            Assert.AreEqual(object2, poppedObject2);
            Assert.AreEqual(object1, poppedObject1);
        }
    }
}
