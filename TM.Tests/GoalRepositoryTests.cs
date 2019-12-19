using System;
using System.Linq;
using TM.Core;
using TM.Core.Models;
using Xunit;

namespace TM.Tests
{
    public class GoalRepositoryTests
    {
        [Fact]
        public void Can_Create_Goal()
        {
            // Prepare
            var goalRepository = new GoalRepository();
            var goal = new Goal();
            const string expectedName = "Тестовая задача";
            goal.Name = expectedName;

            // Pre-Validate

            // Perform
            var result = goalRepository.Add(goal);

            // Post-Validate
            Assert.NotNull(result);
            Assert.Equal(result, goalRepository.Goals.First());
            Assert.Equal(expectedName, result.Name);
        }

        [Fact]
        public void Can_Edit_Goal()
        {
            //Prepare
            var goalRepository = new GoalRepository();
            const int existedGoalId = 1;
            var oldGoal = new Goal
            {
                Id = existedGoalId,
                Name = "OldName",
                Priority = PriorityType.Low
            };
            var expectedGoal = new Goal
            {
                Id = existedGoalId,
                Name = "New Name",
                Priority = PriorityType.High
            };
            goalRepository.Add(oldGoal);
            //Pre-Validate
            var existedGoal = goalRepository.Goals.First(e => e.Id == existedGoalId);
            
            Assert.Equal(oldGoal.Name, existedGoal.Name);
            Assert.Equal(oldGoal.Priority, existedGoal.Priority);
            
            //Perform
            var result = goalRepository.Edit(expectedGoal);
            
            //Post-Validate
            Assert.Equal(expectedGoal.Id, result.Id);
            Assert.Equal(expectedGoal.Name, result.Name);
            Assert.Equal(expectedGoal.Priority, result.Priority);
        }

        [Fact]
        public void Can_Delete()
        {
            //Prepare
            var goalRepository = new GoalRepository();
            const int existedGoalId = 1;
            var goal = new Goal
            {
                Id = existedGoalId
            };
            goalRepository.Add(goal);
            
            //Pre-Validate
            var existedGoal = goalRepository.Goals.FirstOrDefault(e => e.Id == existedGoalId);
            Assert.NotNull(existedGoal);
            Assert.Equal(existedGoalId, existedGoal.Id);
            
            //Perform
            goalRepository.Delete(goal);
            
            //Post-Validate
            Assert.DoesNotContain(goalRepository.Goals, e => e.Id == existedGoalId);
        }

        [Fact]
        public void Can_Get()
        {
            //Prepare
            var goalRepository = new GoalRepository();
            const int existedGoalId = 1;
            var goal = new Goal
            {
                Id = existedGoalId
            };
            goalRepository.Add(goal);
            //Pre-Validate
            var existedGoal = goalRepository.Goals.First(e => e.Id == existedGoalId);
            
            Assert.Equal(existedGoalId, existedGoal.Id);
            //Perform
            var result = goalRepository.Get(goal.Id);
            //Post-Validate
            Assert.Equal(result, goal);
        }
    }
}