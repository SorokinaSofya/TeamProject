using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;
using TM.Core.Models;
using TM.Core;
using TM.Core.Configuration;

namespace TM.Data
{
    public class Storage
    {
        private string path;
        Configurator config = new Configurator();
        public void Rewrite(List<Goal> goals, int lastID)
        {
            path = config.GetConfig().path;
            var tmpData = goals;
            int i = 0;
            File.Create(path).Close();
            StreamWriter data = new StreamWriter(path);
            while (i <= tmpData.Count())
            {
                if (i == 0)
                {
                    data.WriteLine("lastId = {0}", lastID);
                }
                else
                {
                    data.WriteLine("{0},{1},{2},{3},{4},{5},{6}", goals[i - 1].ID, goals[i - 1].Name, goals[i - 1].Text, goals[i - 1].Deadline, goals[i - 1].Timestamp, goals[i - 1].Priority, goals[i - 1].IsDone);
                }
                i++;
            }
            data.Close();
        }

        public int GetLastID()
        {
            var goals = GetAll();
            var lastGoal = goals.LastOrDefault();
            if (lastGoal != null)
            {
                var lastID = lastGoal.ID;
                return lastID;
            }
            else
            {
                var lastID = 0;
                return lastID;
            }
        }

        public List<Goal> GetAll()
        {
            path = @"" + config.GetConfig().path;
            List<Goal> goals = new List<Goal>();
            int i = 1;
            var tmpGoals = File.ReadLines(path);
            while (i < tmpGoals.Count())
            {
                Goal goal = new Goal();
                goal.ID = int.Parse(tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[0]);
                goal.Name = tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[1];
                goal.Text = tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[2];
                goal.Deadline = DateTime.Parse(tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[3]);
                goal.Timestamp = DateTime.Parse(tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[4]);
                goal.Priority = GetPriority(tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[5]);
                goal.IsDone = bool.Parse(tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[6]);
                goals.Add(goal);
                i++;
            }
            return goals;
        }

        private PriorityType GetPriority(string tmpPriority)
        {
            PriorityType priority;
            switch (tmpPriority)
            {
                case "High":
                    priority = Core.Models.PriorityType.High;
                    break;
                case "Middle":
                    priority = Core.Models.PriorityType.Middle;
                    break;
                case "Low":
                    priority = Core.Models.PriorityType.Low;
                    break;
                default:
                    priority = Core.Models.PriorityType.High;
                    break;
            }
            return priority;
        }
    }
}
