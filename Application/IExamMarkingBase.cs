﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application {

    // Define an interface for the exam marking service
    public interface IExamMarkingBase {
        // Declare a method that accepts an exam and returns a Task<Exam> after auto-marking the exam
        Task<Exam> ExamAutoMarkingService(Exam exam);
    }
}
