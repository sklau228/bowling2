using bowling;
using bowling.Controllers;
using System;
using Xunit;

namespace Bowling.Test
{
    public class BowlingControllerTests
    {
        [Fact]
        public void Test1()
        {
            //arange
            var controller = new BowlingController();
            payload p = new payload();
            int[] arr = {1,1,1,1};
            p.pinDowned = arr;
            Microsoft.AspNetCore.Mvc.ActionResult actionResult = controller.GetBowlingMark(p);
            Response resp = actionResult;

            //act
            //assert
        }
    }
}
