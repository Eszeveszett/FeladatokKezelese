using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeladatokKezelese.Data.Class
{
    internal class Tasks : INotifyPropertyChanged, IDataErrorInfo
    {
        private int startYear;

        public int StartYear
        {
            get { return startYear; }
            set { startYear = value; onPropertyChanged("StartYear"); }
        }

        private int startMonth;

        public int StartMonth
        {
            get { return startMonth; }
            set { startMonth = value; onPropertyChanged("StartMonth"); }
        }

        private int startDay;

        public int StartDay
        {
            get { return startDay; }
            set { startDay = value; onPropertyChanged("StartDay"); }
        }

        private int startHour;

        public int StartHour
        {
            get { return startHour; }
            set { startHour = value; onPropertyChanged("StartHour"); }
        }

        private int taskPeriod;

        public int TaskPeriod
        {
            get { return taskPeriod; }
            set { taskPeriod = value; onPropertyChanged("TaskPeriod"); }
        }

        private string taskName;

        public string TaskName
        {
            get { return taskName; }
            set { taskName = value; onPropertyChanged("TaskName"); }
        }

        private string taskDescription;

        public string TaskDescription
        {
            get { return taskDescription; }
            set { taskDescription = value; onPropertyChanged("TaskDescription"); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void onPropertyChanged(string tulajdonsagnev)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagnev));
        }
        
        public string Error => throw new NotImplementedException();
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "StartYear":
                        if (StartYear <= 0) return "Adja meg a kezdö évét!";
                        break;

                    case "StartMonth":
                        if (StartMonth <= 0) return "Adja meg a kezdő hónapot!";
                        break;

                    case "StartDay":
                        if (StartDay <= 0) return "Adja meg a kezdö napot!";
                        break;

                    case "StartHour":
                        if (StartHour <= 0) return "Kötelező kitölteni!";
                        break;

                    case "TaskPeriod":
                        if (TaskPeriod <= 0) return "Hibás Adat";
                        break;

                    case "TaskName":
                        if (string.IsNullOrEmpty(this.TaskName)) return "Kötelező kitölteni!";
                        break;

                    case "TaskDescription":
                        if (string.IsNullOrEmpty(this.TaskDescription)) return "Kötelező kitölteni!";
                        break;

                    default:
                        break;
                }
                return null;
            }
        }




        public Tasks()
        {

        }

    }
}
