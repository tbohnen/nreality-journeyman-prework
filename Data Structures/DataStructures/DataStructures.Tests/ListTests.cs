using NUnit.Framework;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using generic = System.Collections.Generic;

namespace DataStructures.Tests
{
    [TestFixture]
    class ListTests
    {
        [TestCase(2)]
        [TestCase(5)]
        public void AddNItemsToQueue_CountEqualToN(int numberOfItemsToAdd)
        {
            Queue<string> customQueue = new Queue<string>();
            for (int i = 0; i < numberOfItemsToAdd; i++)
            {
                customQueue.Enqueue("");
            }
            
            Assert.AreEqual(numberOfItemsToAdd, customQueue.Length);
            
        }

        [TestCase(5)]
        public void EnqeueNItemsAndDeqeueFirstItem_FirstItemAdded(int numberOfItemsToAdd)
        {
            Queue<string> customQueue = new Queue<string>();
            var firstItem = "1";
            customQueue.Enqueue(firstItem);

            for (int i = 1; i < numberOfItemsToAdd - 1; i++)
            {
                customQueue.Enqueue(i.ToString());
            }

            var deqeuedItem = customQueue.Dequeue();

            Assert.AreEqual(firstItem, deqeuedItem);

        }

        [TestCase("a,b,c,d,e,f,g,h,i")]
        [TestCase("a,b,c,d,e,f,g,h,i,j,k,l,m,n")]
        public void TestThatItemsEnqeueAndDeqeueInCorrectOrderWithMultipleEnqeueAndDeqeues(string stringItemsToTest)
        {
            var itemsToTest = stringItemsToTest.Split(',');

            var queueToTestAgainst = new System.Collections.Generic.Queue<string>();
            var customQueue = new Queue<string>();

            for (int i = 0; i < itemsToTest.Length / 2; i++)
            {
                customQueue.Enqueue(itemsToTest[i]);
                queueToTestAgainst.Enqueue(itemsToTest[i]);
            }

            customQueue.Dequeue();
            queueToTestAgainst.Dequeue();
            customQueue.Dequeue();
            queueToTestAgainst.Dequeue();
            customQueue.Dequeue();
            queueToTestAgainst.Dequeue();


            for (int i = itemsToTest.Length / 2; i < itemsToTest.Length; i++)
            {
                customQueue.Enqueue(itemsToTest[i]);
                queueToTestAgainst.Enqueue(itemsToTest[i]);
            }

            int queueLengthLeft = queueToTestAgainst.Count;

            for (int i = 0; i < queueLengthLeft; i++)
            {
                var deqeueItem = customQueue.Dequeue();
                var deqeueItemToTest = queueToTestAgainst.Dequeue();
                Assert.AreEqual(deqeueItem, deqeueItemToTest);
                Console.WriteLine(deqeueItem, deqeueItemToTest);
            }

        }



        [TestCase(0)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(11)]
        public void EnqeueNItemsAndDeqeueNItems_ReturnsAllItemsInOrder(int numberOfItemsToAdd)
        {

            var queueToTestAgainst = new System.Collections.Generic.Queue<string>();
            Queue<string> customQueue = new Queue<string>();

            AddNItemsToQeues(numberOfItemsToAdd, queueToTestAgainst, customQueue);

            var deqeuedItems = DeqeueNItemsAndReturn(numberOfItemsToAdd, queueToTestAgainst, customQueue);

            foreach (var item in deqeuedItems)
            {
                Assert.AreEqual(item.Key, item.Value);
            }
        }

        private static generic.Dictionary<int, int> DeqeueNItemsAndReturn(int numberOfItemsToAdd, System.Collections.Generic.Queue<string> queueToTestAgainst, Queue<string> customQueue)
        {
            var deqeuedItems = new generic.Dictionary<int, int>();

            for (int i = 0; i < numberOfItemsToAdd; i++)
            {
                var deqeuedItem = customQueue.Dequeue();
                var deqeuedItemFromTestQueue = queueToTestAgainst.Dequeue();
                deqeuedItems.Add(deqeuedItem.GetHashCode(), deqeuedItemFromTestQueue.GetHashCode());
            }

            return deqeuedItems;
        }

        private static void AddNItemsToQeues(int numberOfItemsToAdd, System.Collections.Generic.Queue<string> queueToTestAgainst, Queue<string> customQueue)
        {
            for (int i = 0; i < numberOfItemsToAdd; i++)
            {
                customQueue.Enqueue(i.ToString());
                queueToTestAgainst.Enqueue(i.ToString());
            }
        }



    }
}
