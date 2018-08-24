using System;
using System.Windows;
using System.Windows.Controls;
using CustomPresentationControls.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomPresentationControls.Test
{
    [TestClass]
    public class ExtensionsTests
    {
        [TestMethod]
        public void FindNearestAncestorTag_WhenValidTagAvailable_ReturnsTag()
        {
            //ARRANGE:
            StackPanel panel = new StackPanel();
            panel.Tag = true;
            Border border = new Border();
            Button button = new Button();
            //ACT:
            border.Child = button;
            panel.Children.Add(border);
            var tag = button.FindNearestAncestorTag();
            //ASSERT:
            Assert.IsTrue((bool)tag);
        }
        [TestMethod]
        public void FindNthNearestAncestorTag_WhenNIsTwo_ReturnsSecondTagEncounteredInHierarchy()
        {
            //ARRANGE:
            StackPanel panel = new StackPanel();
            panel.Tag = true;
            Border border = new Border();
            border.Tag = false;
            Button button = new Button();
            //ACT:
            border.Child = button;
            panel.Children.Add(border);
            var tag = button.FindNthNearestAncestorTag(2);
            //ASSERT:
            Assert.IsTrue((bool)tag);

        }
        [TestMethod]
        public void FindParent_WhenNoParentCanBeFound_ReturnsNull()
        {
            //ARRANGE:
            StackPanel panel = new StackPanel();
            Button button = new Button();
            Border border = new Border();
            //ACT:
            border.Child = button;
            panel.Children.Add(border);
            var parent = button.FindParent<Grid>();
            //ASSERT:
            Assert.IsNull(parent);
        }
        [TestMethod]
        public void FindParent_WhenValidParentRequested_ReturnsType()
        {
            //ARRANGE:
            StackPanel panel = new StackPanel();
            Button button = new Button();
            Border border = new Border();
            //ACT:
            border.Child = button;
            panel.Children.Add(border);
            var parent = button.FindParent<StackPanel>();
            //ASSERT:
            Assert.IsNotNull(parent);

        }
    }
}
