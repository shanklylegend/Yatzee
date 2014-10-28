using System;
using System.CodeDom;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YahtzeeGame;

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
			// arrange
			
			var category = new CategoryOne();

			// act
			var result = _yahtzee.Score("1,2,3,4,5", category);

			// assert
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void ScoreCategoryTwos_ReturnsCorrectScore()
		{
			// arrange
			var category = new CategoryTwo();

			// act
			var result = _yahtzee.Score("1,2,3,2,5", category);
			
			// assert
			Assert.AreEqual(4, result);		
		}		
		
		[TestMethod]
		public void ScoreCategoryTwos_NoTwosReturnsZero()
		{
			// arrange
			var category = new CategoryTwo();

			// act
			var result = _yahtzee.Score("5,1,3,6,5", category);
			
			// assert
			Assert.AreEqual(0, result);		
		}		
		
		[TestMethod]
		public void ScoreCategoryThrees_ReturnsCorrectScore()
		{
			// arrange
			var category = new CategoryThree();

			// act
			var result = _yahtzee.Score("5,1,3,6,5", category);
			
			// assert
			Assert.AreEqual(3, result);		
		}	
		
		[TestMethod]
		public void ScoreCategoryThrees_NoThrees_ReturnsZero()
		{
			// arrange
			var category = new CategoryThree();

			// act
			var result = _yahtzee.Score("5,1,2,6,5", category);
			
			// assert
			Assert.AreEqual(0, result);		
		}

		[TestMethod]
		public void ScoreCategoryFours_ReturnsCorrectScore()
		{
			// arrange
			var category = new CategoryFour();

			// act
			var result = _yahtzee.Score("2,3,4,4,2", category);

			// assert
			Assert.AreEqual(8, result);
		}		
		
		[TestMethod]
		public void ScoreCategoryFours_NoFours_ReturnsZero()
		{
			// arrange
			var category = new CategoryFour();

			// act
			var result = _yahtzee.Score("2,3,2,1,2", category);

			// assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void ScoreCategoryFives_ReturnsSum()
		{
			// arrange 
			var category = new CategoryFive();

			// act
			var result = _yahtzee.Score("5,5,5,2,1", category);

			// assert
			Assert.AreEqual(15, result);
		}		
		
		[TestMethod]
		public void ScoreCategoryFives_NoFives_ReturnsZero()
		{
			// arrange 
			var category = new CategoryFive();

			// act
			var result = _yahtzee.Score("4,2,3,2,1", category);

			// assert
			Assert.AreEqual(0, result);
		}		
		
		[TestMethod]
		public void ScoreCategorySixes_ReturnsSum()
		{
			// arrange 
			var category = new CategorySix();

			// act
			var result = _yahtzee.Score("5,6,6,6,6", category);

			// assert
			Assert.AreEqual(24, result);
		}		
		
		[TestMethod]
		public void ScoreCategoryFives_NoSixes_ReturnsZero()
		{
			// arrange 
			var category = new CategorySix();

			// act
			var result = _yahtzee.Score("4,2,3,2,1", category);

			// assert
			Assert.AreEqual(0, result);
		}
		
		[TestMethod]
		public void ScoreCategoryPairs_ReturnsValueOfHighestPair()
		{
			// arrange
			var category = new CategoryPair();

			// act
			var result = _yahtzee.Score("3,3,3,4,4", category);
			
			// assert
			Assert.AreEqual(8, result);		
		}		
		
		[TestMethod]
		public void ScoreCategoryPairs_ReturnsZeroIfNoPairsRolled()
		{
			// arrange
			var category = new CategoryPair();

			// act
			var result = _yahtzee.Score("3,1,2,5,6", category);
			
			// assert
			Assert.AreEqual(0, result);		
		}

		[TestMethod]
		public void ScoreTwoPairs_TwoPairsRolled_ReturnsSumOfBothPairs()
		{
			// arrange 
			var category = new CategoryTwoPairs();

			// act
			var result = _yahtzee.Score("1,1,2,3,3", category);

			// assert
			Assert.AreEqual(8, result);
		}		
		
		[TestMethod]
		public void ScoreTwoPairs_LessThanTwoPairsRolled_ReturnsZero()
		{
			// arrange 
			var category = new CategoryTwoPairs();

			// act
			var result = _yahtzee.Score("1,4,2,3,3", category);

			// assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void ScoreThreeOfAKind_ThreeOfAKindRolled_RetursSumOfThreeOfKind()
		{
			// arrange 
			var category = new CategoryThreeOfAKind();

			// act
			var result = _yahtzee.Score("3,3,3,4,5", category);

			// assert

			Assert.AreEqual(9, result);
		}

		[TestMethod]
		public void ScoreThreeOfAKind_ThreeOfAKindNotRolled_RetursZero()
		{
			// arrange 
			var category = new CategoryThreeOfAKind();

			// act
			var result = _yahtzee.Score("3,3,4,4,5", category);

			// assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void ScoreFourOfAKind_FourOfAKindRolled_ReturnsSumOfFourOfAKind()
		{
			// arrange
			var category = new CategoryFourOfAKind();

			// act
			var result = _yahtzee.Score("2,2,2,2,5", category);

			// assert
			Assert.AreEqual(8, result);
		}		
		
		[TestMethod]
		public void ScoreFourOfAKind_FourOfAKindNotRolled_ReturnsZero()
		{
			// arrange
			var category = new CategoryFourOfAKind();

			// act
			var result = _yahtzee.Score("2,2,2,5,5", category);

			// assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void ScoreSmallStraight_SmallStraightRolled_ReturnsSum()
		{
			// arrange
			var category = new CategorySmallStraight();

			// act
			var result = _yahtzee.Score("1,2,3,4,5", category);

			// assert
			Assert.AreEqual(15, result);
		}
		
		[TestMethod]
		public void ScoreSmallStraight_SmallStraightNotRolled_ReturnsZero()
		{
			// arrange
			var category = new CategorySmallStraight();

			// act
			var result = _yahtzee.Score("1,2,3,6,5", category);

			// assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void ScoreLargeStraight_LargeStraightRolled_ReturnsSum()
		{
			// arrange
			var category = new CategoryLargeStraight();

			// act
			var result = _yahtzee.Score("2,3,4,5,6", category);

			// assert
			Assert.AreEqual(20, result);
		}		
		
		[TestMethod]
		public void ScoreLargeStraight_LargeStraightNotRolled_ReturnsZero()
		{
			// arrange
			var category = new CategoryLargeStraight();

			// act
			var result = _yahtzee.Score("2,3,4,6,6", category);

			// assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void ScoreFullHouse_FullHouseRolled_ReturnsSum()
		{
			// arrange
			var category = new CategoryFullHouse();

			// act
			var result = _yahtzee.Score("1,1,2,2,2", category);
			
			// assert
			Assert.AreEqual(8, result);
		}		
		
		[TestMethod]
		public void ScoreFullHouse_FullHouseNotRolled_ReturnsZero()
		{
			// arrange
			var category = new CategoryFullHouse();

			// act
			var result = _yahtzee.Score("1,1,4,2,2", category);
			
			// assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void ScoreChance_ReturnsSum()
		{
			// arrange
			var category = new CategoryChance();

			// act
			var result = _yahtzee.Score("1,1,3,3,6", category);

			// assert
			Assert.AreEqual(14, result);
		}

		[TestMethod]
		public void ScoreYathzee_YahtzeeRolled_ReturnsYahtzeeSum()
		{
			// arrange
			var category = new CategoryYahtzee();

			// act
			var result = _yahtzee.Score("1,1,1,1,1", category);
			
			// assert
			Assert.AreEqual(50, result);
		}	
		
		[TestMethod]
		public void ScoreYathzee_YahtzeeNotRolled_ReturnsZero()
		{
			// arrange
			var category = new CategoryYahtzee();

			// act
			var result = _yahtzee.Score("1,1,1,1,2", category);
			
			// assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void ScoreMax_YaztzeeRolled_ReturnsYahtzeeScore()
		{
			// arrange

			// act
			

			// assert
			Assert.AreEqual(50, _yahtzee.ScoreMax("1,1,1,1,1")); // Yatzee
			Assert.AreEqual(25, _yahtzee.ScoreMax("6,6,6,6,1")); // Chance
		
		}

	}
}
