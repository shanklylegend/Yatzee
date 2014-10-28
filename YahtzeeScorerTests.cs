using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee;

namespace Yatzee
{
	[TestClass]
	public class YahtzeeScorerTests
	{
		private YahtzeeScorer _yahtzee;

		[TestInitialize]
		public void TestInit()
		{
			_yahtzee = new YahtzeeScorer();
		}

		[TestMethod]
		public void ScoreCategoryOnes()
		{
			var category = new CategoryOne();

			Assert.AreEqual(0, _yahtzee.Score("2,2,3,4,5", category));
			Assert.AreEqual(1, _yahtzee.Score("1,2,3,4,5", category));
			Assert.AreEqual(2, _yahtzee.Score("1,1,3,4,5", category));
			Assert.AreEqual(3, _yahtzee.Score("1,1,1,4,5", category));
			Assert.AreEqual(4, _yahtzee.Score("1,1,1,1,5", category));
			Assert.AreEqual(5, _yahtzee.Score("1,1,1,1,1", category));
		}

		[TestMethod]
		public void ScoreCategoryTwos()
		{
			var category = new CategoryTwo();

			Assert.AreEqual(0, _yahtzee.Score("1,1,3,4,5", category));
			Assert.AreEqual(2, _yahtzee.Score("2,1,3,4,5", category));
			Assert.AreEqual(4, _yahtzee.Score("1,2,2,4,5", category));
			Assert.AreEqual(6, _yahtzee.Score("1,2,2,2,5", category));
			Assert.AreEqual(8, _yahtzee.Score("2,2,2,2,5", category));
			Assert.AreEqual(10, _yahtzee.Score("2,2,2,2,2", category));	
		}			
		
		[TestMethod]
		public void ScoreCategoryThrees()
		{
			var category = new CategoryThree();
			Assert.AreEqual(0, _yahtzee.Score("1,1,4,4,5", category));
			Assert.AreEqual(3, _yahtzee.Score("2,1,3,4,5", category));
			Assert.AreEqual(6, _yahtzee.Score("3,2,3,4,5", category));
			Assert.AreEqual(9, _yahtzee.Score("3,3,2,3,6", category));
			Assert.AreEqual(12, _yahtzee.Score("3,3,2,3,3", category));
			Assert.AreEqual(15, _yahtzee.Score("3,3,3,3,3", category));	
		}	
		
		[TestMethod]
		public void ScoreCategoryFours()
		{
			var category = new CategoryFour();
			Assert.AreEqual(0, _yahtzee.Score("1,1,3,2,5", category));
			Assert.AreEqual(4, _yahtzee.Score("2,1,3,4,5", category));
			Assert.AreEqual(8, _yahtzee.Score("3,4,3,4,5", category));
			Assert.AreEqual(12, _yahtzee.Score("3,4,4,3,4", category));
			Assert.AreEqual(16, _yahtzee.Score("4,4,4,3,4", category));
			Assert.AreEqual(20, _yahtzee.Score("4,4,4,4,4", category));	
		}	
		
		[TestMethod]
		public void ScoreCategoryFives()
		{
			var category = new CategoryFive();
			Assert.AreEqual(0, _yahtzee.Score("1,1,4,4,2", category));
			Assert.AreEqual(5, _yahtzee.Score("2,1,3,4,5", category));
			Assert.AreEqual(10, _yahtzee.Score("3,2,5,4,5", category));
			Assert.AreEqual(15, _yahtzee.Score("5,5,5,3,6", category));
			Assert.AreEqual(20, _yahtzee.Score("3,5,5,5,5", category));
			Assert.AreEqual(25, _yahtzee.Score("5,5,5,5,5", category));	
		}		
		
		[TestMethod]
		public void ScoreCategorySix()
		{
			var category = new CategorySix();
			Assert.AreEqual(0, _yahtzee.Score("1,1,4,4,2", category));
			Assert.AreEqual(6, _yahtzee.Score("2,1,3,6,5", category));
			Assert.AreEqual(12, _yahtzee.Score("3,6,6,4,5", category));
			Assert.AreEqual(18, _yahtzee.Score("6,6,5,3,6", category));
			Assert.AreEqual(24, _yahtzee.Score("3,6,6,6,6", category));
			Assert.AreEqual(30, _yahtzee.Score("6,6,6,6,6", category));	
		}		
				
		[TestMethod]
		public void ScoreCategoryPairs()
		{
			var category = new CategoryPair();
			Assert.AreEqual(0, _yahtzee.Score("1,2,3,4,5", category));
			Assert.AreEqual(2, _yahtzee.Score("2,1,1,6,5", category));
			Assert.AreEqual(4, _yahtzee.Score("1,1,2,2,5", category));
			Assert.AreEqual(12, _yahtzee.Score("6,6,5,5,5", category));
		}		

		[TestMethod]
		public void ScoreTwoPairs()
		{
			var category = new CategoryTwoPairs();
			Assert.AreEqual(0, _yahtzee.Score("1,2,3,4,5", category));
			Assert.AreEqual(0, _yahtzee.Score("1,1,1,1,5", category));
			Assert.AreEqual(6, _yahtzee.Score("2,1,1,2,5", category));
			Assert.AreEqual(22, _yahtzee.Score("6,6,5,5,5", category));
		}		

		[TestMethod]
		public void ScoreThreeOfAKind()
		{ 
			var category = new CategoryThreeOfAKind();
			Assert.AreEqual(0, _yahtzee.Score("1,2,3,4,5", category));
			Assert.AreEqual(3, _yahtzee.Score("1,1,1,1,5", category));
			Assert.AreEqual(3, _yahtzee.Score("1,1,1,1,1", category));
			Assert.AreEqual(18, _yahtzee.Score("6,6,6,5,5", category));
		}

		[TestMethod]
		public void ScoreFourOfAKind()
		{
			var category = new CategoryFourOfAKind();
			Assert.AreEqual(0, _yahtzee.Score("1,2,3,4,5", category));
			Assert.AreEqual(4, _yahtzee.Score("1,1,1,1,5", category));
			Assert.AreEqual(4, _yahtzee.Score("1,1,1,1,1", category));
			Assert.AreEqual(24, _yahtzee.Score("6,6,6,6,5", category));
		}		

		[TestMethod]
		public void ScoreSmallStraight()
		{
			var category = new CategorySmallStraight();

			Assert.AreEqual(0, _yahtzee.Score("2,3,4,5,6", category));
			Assert.AreEqual(15, _yahtzee.Score("1,2,3,4,5", category));
		}

		[TestMethod]
		public void ScoreLargeStraight()
		{
			var category = new CategoryLargeStraight();
			Assert.AreEqual(0, _yahtzee.Score("1,2,3,4,5", category));
			Assert.AreEqual(20, _yahtzee.Score("2,3,4,5,6", category));
		}		

		[TestMethod]
		public void ScoreFullHouse()
		{
			var category = new CategoryFullHouse();
			Assert.AreEqual(0, _yahtzee.Score("1,1,1,1,1", category));
			Assert.AreEqual(0, _yahtzee.Score("1,2,2,2,2", category));
			Assert.AreEqual(0, _yahtzee.Score("1,2,2,3,3", category));
			Assert.AreEqual(8, _yahtzee.Score("1,1,2,2,2", category));
			Assert.AreEqual(28, _yahtzee.Score("6,6,5,5,6", category));
		}		

		[TestMethod]
		public void ScoreChance()
		{
			var category = new CategoryChance();
			Assert.AreEqual(5, _yahtzee.Score("1,1,1,1,1", category));
			Assert.AreEqual(14, _yahtzee.Score("1,1,3,3,6", category));
			Assert.AreEqual(30, _yahtzee.Score("6,6,6,6,6", category));
		}

		[TestMethod]
		public void ScoreYathzee()
		{
			var category = new CategoryYahtzee();
			Assert.AreEqual(0, _yahtzee.Score("2,1,1,1,1", category));
			Assert.AreEqual(50, _yahtzee.Score("6,6,6,6,6", category));
			Assert.AreEqual(50, _yahtzee.Score("1,1,1,1,1", category));
		}	

		[TestMethod]
		public void ScoreMax()
		{
			Assert.AreEqual(50, _yahtzee.ScoreMax("1,1,1,1,1")); // Yatzee
			Assert.AreEqual(25, _yahtzee.ScoreMax("6,6,6,6,1")); // Chance
		}

	}
}
