﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_Table_Arranging_Program.Class;

namespace Time_Table_Arranging_Program.Model {
    public class BinarizedSlotModel : IIntersectionCheckable<BinarizedSlotModel> {
        private int _day;
        private int _timePeriod;
        private int _weekNumber;
        private string _code;
        private string _type;
        private int _number;
        public string Code => _code;
        public string Type => _type;
        public int Number => _number;
        public int Day {
            get => _day;
            set => _day = value;
        }

        public int TimePeriod {
            get => _timePeriod;
            set => _timePeriod = value;
        }

        public BinarizedSlotModel(Slot s) {
            _day = s.Day.ToBinary();
            _timePeriod = s.TimePeriod.ToBinary();
            _weekNumber = s.WeekNumber.ToBinary();
            _code = s.Code;
            _type = s.Type;
            _number = int.Parse(s.Number);
        }

        public bool IntersectWith(BinarizedSlotModel other) {
            if (_code == other._code && _type == other._type && _number != other._number) return true;
            if ((_day & other._day) == 0) return false;
            if((_timePeriod & other._timePeriod)==0) return false;
            return (_weekNumber & other._weekNumber) != 0;

        }

        public override string ToString() {
            return $"{Code} [{Type}-{Number}]";
        }
    }
}
