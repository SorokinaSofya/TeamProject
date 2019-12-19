using TM.Core;
using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;
using TM.Core.Models;

namespace TM.Data
{
    class Storage
    {
        public void Add(List<Goal> goals)
        {
            StreamWriter data = new StreamWriter("data.txt");
            var tmpData = File.ReadLines("data.txt");
            int i = 0;
            File.Create("data.txt").Close();
            while (i <= tmpData.Count())
            {
                if (i == 0)
                {
                    data.WriteLine("lastId = {}", goals[goals.Count-1].ID);
                }
                else
                {
                    data.WriteLine("{0},{1},{2},{3},{4},{5},{6}",goals[i-1].ID, goals[i - 1].Name, goals[i - 1].Text, goals[i - 1].Deadline, goals[i - 1].Timestamp, goals[i - 1].Priority, goals[i - 1].IsDone);
                }
                i++;
            }
        }
        public void CreateFile()
        {
            if (!(File.Exists("data.txt")))
            {
                StreamWriter data = new StreamWriter("data.txt");
                data.WriteLine("lastId = 0");
            }
        }

        public void Delete(int id)
        {
            StreamWriter data = new StreamWriter("data.txt");
            var goals = GetAll();
            goals.Remove(goals.First(e => e.ID == id));
            var lastId = GetLastID();
            File.Create("data.txt").Close();
            int i = 0;
            while (i < goals.Count)
            {
                if (i == 0)
                {
                    data.WriteLine("lastId = {}", lastId);
                }
                else
                {
                    data.WriteLine("{0},{1},{2},{3},{4},{5},{6}", goals[i-1].ID, goals[i-1].Name, goals[i-1].Text, goals[i-1].Deadline, goals[i-1].Timestamp, goals[i-1].Priority, goals[i-1].IsDone);
                }
                i++;
            }
        }
        public int GetLastID()
        {
            var iDstring = File.ReadLines("data.txt").First();
            var lastID = int.Parse(iDstring.Split(new char[] { ' ' })[2]);
            return lastID;
        }
        public List<Goal> GetAll()
        {
            var goals = new List<Goal>();
            var goal = new Goal();
            int i = 1;
            var tmpGoals = File.ReadLines("data.txt");
            while (i < tmpGoals.Count())
            {
                if (tmpGoals.ElementAt(i) != "")
                {
                    goal.ID = int.Parse(tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[0]);
                    goal.Name = tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[1];
                    goal.Text = tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[2];
                    goal.Deadline = DateTime.Parse(tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[3]);
                    goal.Timestamp = DateTime.Parse(tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[4]);
                    goal.Priority = GetPriority(tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[5]);
                    goal.IsDone = bool.Parse(tmpGoals.ElementAt(i).ToString().Split(new char[] { ',' })[6]);
                    goals.Add(goal);
                }
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
