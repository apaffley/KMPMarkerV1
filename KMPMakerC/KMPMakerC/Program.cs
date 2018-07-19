using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace KMPMakerC
{

    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            KMPControl controller = new KMPControl();

            home form = new home(controller);
            form.ShowDialog();

        }
    }

    public static class FileHandling
    {
        public static void SaveFile(allData inKMPData, string filePath)
        {

            try
            {

                using (Stream stream = File.Open(filePath, FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, inKMPData);
                }
            }
            catch (Exception c)
            {
                MessageBox.Show("Sorry the save failed. " + c.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public static string SaveFileAs(allData inKMPData)
        {
            string filePath = "";
            try
            {

                SaveFileDialog saveForm = new SaveFileDialog();
                saveForm.DefaultExt = saveForm.Filter = "KMP files (*.kmp)|*.kmp";
                if (saveForm.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveForm.FileName.ToString();
                    SaveFile(inKMPData, filePath);
                }
                return filePath;
            }
            catch
            {
                MessageBox.Show("Sorry could not access the save file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public static allData OpenFile(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (allData)binaryFormatter.Deserialize(stream);
            }
        }

        public static List<string> OpenTXTFile()
        {
            List<string> returnList = new List<string>();
            OpenFileDialog openFileD = new OpenFileDialog();
            openFileD.Filter = "TXT files (*.txt)|*.txt";
            if (openFileD.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    string path = openFileD.FileName;
                    string[] lines = File.ReadAllLines(path);

                    foreach (string s in lines)
                    {
                        returnList.Add(s);
                    }
                }
                catch
                {
                }
            }
            return returnList;
        }

        public static void ExportKMP(List<FeedbackData> allFeedbackToExport)
        {
            SaveFileDialog saveTXT = new SaveFileDialog();
            saveTXT.Filter = "TXT files (*.txt)|*.txt";
            if (saveTXT.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveTXT.FileName);
                try
                {
                    writer.WriteLine("Date|Faculty Name|Teacher Name|Topic Name|Topics Covered 1|Topics Covered 2|Student Name|Target Grade|Achieved Grade|Effort Grade|Feedback WWW|Feedback TIF");
                    foreach (FeedbackData d in allFeedbackToExport)
                    {
                        try
                        {
                            string exportLine = d.date + "|" + d.facultyName + "|" + d.teacherName + "|" + d.topicName + "|" + d.topicsCovered[0] + "|" + d.topicsCovered[1] + "|" + d.studentName + "|" + d.targetGrade + "|" + d.acheivedGrade + "|" + d.effortGrade + "|" + d.feedbackWWWs + "|" + d.feedbackTIFs;
                            writer.WriteLine(exportLine);
                        }
                        catch
                        {
                        }
                    }
                    writer.Close();
                }
                catch
                {
                    MessageBox.Show("Sorry, export failed");
                }
            }
        }

        public static bool WriteListToTXT(List<string> inList)
        {
            SaveFileDialog saveTXT = new SaveFileDialog();
            saveTXT.Filter = "TXT files (*.txt)|*.txt";
            if (saveTXT.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllLines(saveTXT.FileName, inList.ToArray());
                    return true;
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }

   
        

        [Serializable]
        public class KMPControl
        {
            private allData newKMP;
            private string currentFilePath = "";
            private bool alreadySaved = false;

            public bool AlreadySaved
            {
                get
                {
                    return alreadySaved;
                }
            }

            public allData CreateNewKMP(string inKMPName, string inTeacher, List<string> inTopicsCovered, string inFacultyName, DateTime inDate)
            {
                newKMP = new allData();
                newKMP.assignmentName = inKMPName;
                newKMP.teacherName = inTeacher;
                newKMP.topicsCovered = inTopicsCovered;
                newKMP.facultyName = inFacultyName;
            newKMP.dateOfKMP = inDate;
                alreadySaved = false;
                return newKMP;
            }

            public bool SaveKMPFileAs()
            {
                currentFilePath = FileHandling.SaveFileAs(newKMP);
                alreadySaved = true;
                return true;
            }

            public bool SaveKMP()
            {
                FileHandling.SaveFile(newKMP, currentFilePath);
                alreadySaved = true;
                return true;
            }

            public bool OpenKMP(string filePathIn)
            {
                try
                {
                    newKMP = FileHandling.OpenFile(filePathIn);
                    currentFilePath = filePathIn;
                    alreadySaved = true;
                    return true;
                }
                catch (Exception C)
                {
                    MessageBox.Show("File loading failed, sorry \r\n " + C.ToString());
                    currentFilePath = "";
                    return false;
                }
            }

            public bool OpenCommentsFromFile(bool append)
            {
                try
                {
                    List<string> commentList = new List<string>();
                    bool commentTIF = true;
                    commentList = FileHandling.OpenTXTFile();
                if (commentList.Count != 0)
                {
                    if (append == false)
                    {

                        newKMP.comments = new List<string>();
                        newKMP.TIFs = new List<string>();

                    }

                    foreach (string s in commentList)
                    {
                        if (s.Contains("######"))
                        {
                            commentTIF = false;
                        }
                        else
                        {
                            if (commentTIF == true)
                            {
                                newKMP.comments.Add(s);
                            }
                            else
                            {
                                newKMP.TIFs.Add(s);
                            }
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }

                }
                catch
                {
                    MessageBox.Show("Import Failed");
                    return false;
                }
                
            }

            public void ExportCommentsTXT()
            {
                List<string> exportList = new List<string>();
                foreach (string s in newKMP.comments)
                {
                    exportList.Add(s);
                }
                exportList.Add("######");
                foreach (string s in newKMP.TIFs)
                {
                    exportList.Add(s);
                }
                FileHandling.WriteListToTXT(exportList);
            }

            public allData GetCurrentKMP()
            {
                if (newKMP != null)
                {
                    return newKMP;
                }
                else
                {
                    return new allData();
                }
            }
            public allData GetKMP()
            {
                if (newKMP != null)
                {
                    return newKMP;
                }
                else
                {
                    return null;
                }
            }

        public void PrintSingleKMP(FeedbackData indata)
        {
            
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK) //Runs the printer dialog and checks if the user pressed "OK" before printing
            {

                FeedbackPrinterDocument print = new FeedbackPrinterDocument(indata);
                print.PrinterSettings = printDialog.PrinterSettings;
                print.Print();

            }
        }

        public void PrintAllKMPs()
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK) //Runs the printer dialog and checks if the user pressed "OK" before printing
                {

                    foreach (FeedbackData d in newKMP.AllFeedBackData)
                    {


                        FeedbackPrinterDocument print = new FeedbackPrinterDocument(d);
                        print.PrinterSettings = printDialog.PrinterSettings;
                        print.Print();
                    }
                }
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PrintRange(int min, int max)
        {
            try
            {
                if (min > 0 && max <= newKMP.NumberOfRecords)
                {
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == DialogResult.OK) //Runs the printer dialog and checks if the user pressed "OK" before printing
                    {

                        for (int i = min - 1; i < max; i++)
                        {
                            FeedbackData d = newKMP.AllFeedBackData[i];

                            FeedbackPrinterDocument print = new FeedbackPrinterDocument(d);
                            print.PrinterSettings = printDialog.PrinterSettings;
                            print.Print();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, the range is not valid");
                }
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportKMP()
        {
            FileHandling.ExportKMP(newKMP.AllFeedBackData);
        }

    }
                [Serializable]
        public class allData
        {
            public string assignmentName = "";
            public List<string> comments;
            public List<string> TIFs;
            public List<string> names;
            public List<string> targets;
            public string teacherName = "";
            public List<string> topicsCovered = new List<string>();
            public string facultyName = "";
        public DateTime dateOfKMP = DateTime.Now;

            //private int numberOfRecords = names.Count;

            private List<FeedbackData> allFeedbackData = new List<FeedbackData>();
            public List<FeedbackData> AllFeedBackData
        {
            get
            {
                return allFeedbackData;
            }
        }
        public bool updateFeedbackNameandTarget(int index,string name, string target)
        {
            try
            {
                List<FeedbackData> feedbackDataTemp = AllFeedBackData;
                FeedbackData temp = feedbackDataTemp[index];
                temp.studentName = name;
                temp.targetGrade = target;
                feedbackDataTemp[index] = temp;
                allFeedbackData = feedbackDataTemp;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int NumberOfRecords
        {
            get
            {
                return allFeedbackData.Count;
            }
        }
            private void InitialiseAllData()
            {
                for (int i = 0; i < names.Count; i++)
                {
                    FeedbackData newData = new FeedbackData();
                    newData.studentName = names[i];
                    try
                    {
                        newData.targetGrade = targets[i];
                    }
                    catch
                    {
                        newData.targetGrade = "";
                    }
                newData.facultyName = facultyName;
                newData.teacherName = teacherName;
                newData.topicNote = "";
                newData.date = dateOfKMP;
                newData.topicsCovered = topicsCovered.ToArray();
                    allFeedbackData.Add(newData);
                }
            }

        public bool AddNewRecord(string name, string target)
        {
            FeedbackData newData = new FeedbackData();
            
            try
            {
                newData.topicName = assignmentName;
                newData.studentName = name;
                newData.targetGrade = target;
                newData.facultyName = facultyName;
                newData.teacherName = teacherName;
                newData.topicNote = "";
                newData.date = dateOfKMP;
                newData.topicsCovered = topicsCovered.ToArray();
                allFeedbackData.Add(newData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateAllRecordsCoreData()
        {

            for ( int i = 0; i < allFeedbackData.Count; i++)
            {
                FeedbackData newData = allFeedbackData[i];
            newData.facultyName = facultyName;
            newData.teacherName = teacherName;
                newData.date = dateOfKMP;
                newData.topicName = assignmentName;
            newData.topicNote = "";
                try
                {
                    newData.topicsCovered = topicsCovered.ToArray();
                }
                catch
                {
                    newData.topicsCovered[0] = "";
                    newData.topicsCovered[1] = "";
                }
                allFeedbackData[i] = newData;
        }
        }



            public void IntilaiseAllStudentRecords()
            {
                InitialiseAllData();
            }

            private int myIndex = 0;

            public int CurrentIndex
            {
                get
                {
                    return myIndex;
                }
            }

            private int GetNextIndex()
            {
                if (myIndex + 1 < allFeedbackData.Count)
                {
                    myIndex = myIndex + 1;
                    return myIndex;
                }
                else
                {
                    return myIndex;
                }
            }

            private int GetPreviousIndex()
            {
                if (myIndex - 1 >= 0)
                {
                    myIndex--;
                    return myIndex;
                }
                else
                {
                    return myIndex;
                }

            }

            private int ResetIndex()
            {
                myIndex = 0;
                return myIndex;
            }

            private int GetCurrentRecordIndex()
            {

                return myIndex;

            }

        private int GetLastIndex()
        {
            myIndex = allFeedbackData.Count - 1;
            return myIndex;
        }

            public FeedbackData GetCurrentRecord()
            {
                try
                {
                    return allFeedbackData[GetCurrentRecordIndex()];
                }
                catch
                {
                    FeedbackData d = new FeedbackData();
                    d.studentName = "do not use";
                    return d;
                }
            }

            public FeedbackData GetPreviousRecord()
            {
                return allFeedbackData[GetPreviousIndex()];
            }

            public FeedbackData GetNextRecord()
            {
                return allFeedbackData[GetNextIndex()];
            }

            public FeedbackData GetFirstRecord()
            {
                return allFeedbackData[ResetIndex()];
            }

        public FeedbackData GetLastRecord()
        {
            return allFeedbackData[GetLastIndex()];
        }

            public void returnRecord(FeedbackData inRecord)
            {
                allFeedbackData[GetCurrentRecordIndex()] = inRecord;
            }
        }


    //[Serializable]
    //    public struct FeedbackData
    //    {
    //        public string studentName; //The name of the student
    //        public string topicName; //The name of the topic
    //        public DateTime date; //The date for the feedback
    //        public string teacherName; //The name of the teacher
    //        public string topicNote; //The small amount of text that comes after the teacher
    //        public string targetGrade; //The target grade of the student
    //        public string acheivedGrade; //The acheived grade of the student
    //        public string effortGrade; //The effort grade of the student
    //        public string[] topicsCovered; //The topics covered in the KMP - it is the bullet points below
    //        public string feedbackWWWs; //The WWWs that need to go in the topmost box
    //        public string feedbackTIFs; //The TIFs that need to go in the middle box

    //    }
    
}
