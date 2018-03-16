﻿using System.Collections.Generic;
using System.Windows.Controls;
using Typo.Model.Database;
using Typo.View;

namespace Typo.Controller
{
    internal class OverviewController
    {
        //declaration of the DataBaseController and a list of student objects
        private readonly DatabaseController dataBaseController;

        private readonly List<Student> list;

        //the contstructor initialises the DataBaseController
        public OverviewController()
        {
            dataBaseController = new DatabaseController();
            //initialise the list with all student objects in the database
            list = dataBaseController.GetAllStudents();
        }

        //method for filling the student grid with student information panels
        public void FillStudentGrid(MainWindow mainWindow, WrapPanel StudentPanel)
        {
            foreach (var student in list)
            {
                var studentInformation =
                    new StudentInformation(mainWindow, student);
                StudentPanel.Children.Add(studentInformation);
            }
        }
    }
}