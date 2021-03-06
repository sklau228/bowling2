using scores;
using Xunit;

namespace Bowling.Test
{
    public class BowlingRepoTests
    {
        [Fact]
        public void Test_CheckPerfectGame()
        {
            //arange            
            payload p = new payload();
            int[] arr = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            p.pinDowned = arr;

            string[] resultscore = { "30", "60", "90", "120", "150", "180", "210", "240", "270", "300" };
            bool resultComplete = true;

            //act
            BowlingRepo br = new BowlingRepo();
            Response resp = br.GetMark(p);

            //assert
            Assert.Equal(string.Join(",",resp.frameProgressScores), string.Join(",",resultscore));
            Assert.Equal(resp.gameCompleted, resultComplete);
        }

        [Fact]
        public void Test_CheckIncompleteGame19()
        {
            //arange            
            payload p = new payload();
            int[] arr = { 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9 };
            p.pinDowned = arr;

            string[] resultscore = { "2", "4", "6", "8", "10", "12" };
            bool resultComplete = false;

            //act
            BowlingRepo br = new BowlingRepo();

            Response resp = br.GetMark(p);

            //assert
            Assert.Equal(string.Join(",", resp.frameProgressScores), string.Join(",", resultscore));
            Assert.Equal(resp.gameCompleted, resultComplete);
        }

        [Fact]
        public void Test_CheckIncompleteGame1()
        {
            //arange            
            payload p = new payload();
            int[] arr = {1,1,1,1,1,1,1,1,1,1,1,1};
            p.pinDowned = arr;

            string[] resultscore = { "2", "4","6", "8", "10", "12" };
            bool resultComplete = false;

            //act
            BowlingRepo br = new BowlingRepo();

            Response resp= br.GetMark(p);

            //assert
            Assert.Equal(string.Join(",", resp.frameProgressScores), string.Join(",", resultscore));
            Assert.Equal(resp.gameCompleted, resultComplete);
        }

      
        [Fact]
        public void Test_CheckIncompleteGame2()
        {
            //arange            
            payload p = new payload();
            int[] arr = { 1, 1, 1, 1, 9, 1, 2, 8, 9, 1, 10, 10 };
            p.pinDowned = arr;

            string[] resultscore = { "2", "4", "16", "35", "55","*","*" };
            bool resultComplete = false;

            //act
            BowlingRepo br = new BowlingRepo();
            Response resp = br.GetMark(p);

            //assert
            Assert.Equal(string.Join(",", resp.frameProgressScores), string.Join(",", resultscore));
            Assert.Equal(resp.gameCompleted, resultComplete);
        }

        [Fact]
        public void Test_CheckcompleteGame_lastgame_10_1_9()
        {
            //arange           
            payload p = new payload();
            int[] arr = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 1, 9 };
            p.pinDowned = arr;

            string[] resultscore = { "30", "60", "90", "120", "150", "180", "210", "240", "261", "281" };
            bool resultComplete = true;

            //act
            BowlingRepo br = new BowlingRepo();
            Response resp = br.GetMark(p);

            //assert
            Assert.Equal(string.Join(",", resp.frameProgressScores), string.Join(",", resultscore));
            Assert.Equal(resp.gameCompleted, resultComplete);
        }

        [Fact]
        public void Test_CheckcompleteGame_lastgame_1_9_9()
        {
            //arange           
            payload p = new payload();
            int[] arr = { 10, 10, 10, 10, 10, 10, 10, 10, 10,  1, 9, 9 };
            p.pinDowned = arr;

            string[] resultscore = { "30", "60", "90", "120", "150", "180", "210", "231", "251", "271" };
            bool resultComplete = true;

            //act
            BowlingRepo br = new BowlingRepo();
            Response resp = br.GetMark(p);

            //assert
            Assert.Equal(string.Join(",", resp.frameProgressScores), string.Join(",", resultscore));
            Assert.Equal(resp.gameCompleted, resultComplete);
        }

        [Fact]
        public void Test_CheckcompleteGame_lastgame_1_1()
        {
            //arange      
            payload p = new payload();
            int[] arr = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 1,1 };
            p.pinDowned = arr;

            string[] resultscore = { "30", "60", "90", "120", "150", "180", "210", "231", "243", "245" };
            bool resultComplete = true;

            //act
            BowlingRepo br = new BowlingRepo();
            Response resp = br.GetMark(p);

            //assert
            Assert.Equal(string.Join(",", resp.frameProgressScores), string.Join(",", resultscore));
            Assert.Equal(resp.gameCompleted, resultComplete);
        }


        [Fact]
        public void Test_CheckcompleteGame_lastgame_1()
        {
            //arange           
            payload p = new payload();
            int[] arr = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 1 };
            p.pinDowned = arr;

            string[] resultscore = { "30", "60", "90", "120", "150", "180", "210", "231", "*", "*" };
            bool resultComplete = false;

            //act
            BowlingRepo br = new BowlingRepo();
            Response resp = br.GetMark(p);

            //assert
            Assert.Equal(string.Join(",", resp.frameProgressScores), string.Join(",", resultscore));
            Assert.Equal(resp.gameCompleted, resultComplete);
        }
    }
}
