using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestionData
{

    private string title;
    private string option1;
    private string option2;
    private string option3;
    private int answer_index;
    private int created_by;
    private int created_for;


    public QuestionData(string title, string option1, string option2, string option3, string answerIndex, string createdBy, string createdFor)
    {
        this.title = title;
        this.option1 = option1;
        this.option2 = option2;
        this.option3 = option3;
        this.answer_index = Int32.Parse(answerIndex);
        this.created_by = Int32.Parse(createdBy);
        this.created_for = Int32.Parse(createdFor);
    }
}
