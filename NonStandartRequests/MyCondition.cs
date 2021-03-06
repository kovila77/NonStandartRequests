﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonStandartRequests
{
    class MyCondition
    {
        public readonly int FieldIndex;
        public readonly MyField Field;
        public readonly int ExpressionIndex;
        public readonly string cbExpressionText;
        public readonly MyValueHandle Expression;
        public readonly int CriterionIndex;
        public int LigamentIndex;

        public MyCondition(int FieldIndex, MyField Field, int ExpressionIndex, string cbExpressionText, MyValueHandle Expression, int CriterionIndex, int LigamentIndex)
        {
            this.FieldIndex = FieldIndex;
            this.Field = Field;
            this.ExpressionIndex = ExpressionIndex;
            this.cbExpressionText = cbExpressionText;
            this.Expression = Expression;
            this.CriterionIndex = CriterionIndex;
            this.LigamentIndex = LigamentIndex;
        }
    }
}
