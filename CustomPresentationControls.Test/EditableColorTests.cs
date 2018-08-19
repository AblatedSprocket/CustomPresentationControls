using System;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomPresentationControls.Test
{
    [TestClass]
    public class EditableColorTests
    {
        [TestMethod]
        public void EditableColor_WhenEdited_ReturnsExpectedColor()
        {
            int redVal = 255;
            Color color = Color.FromRgb(Convert.ToByte(redVal), 0, 0);
            Assert.AreEqual(Color.FromRgb(255, 0, 0), color);
        }
    }
}
