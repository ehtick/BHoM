﻿using BHoM.Base.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Structural.Results
{
    public class SlabReinforcement : SlabReinforcement<int, int, int>
    {
        public SlabReinforcement() : base() { }
        public SlabReinforcement(int number, int node, int loadcase, int timeStep, double Axp, double Axm, double Ayp, double Aym)
            : base(number, node, loadcase, timeStep, Axp, Axm, Ayp, Aym)
        { }
    }

    public class SlabReinforcement<TName, TLoadcase, TTimeStep> : Result<TName, TLoadcase, TTimeStep>
         where TName : IComparable
         where TLoadcase : IComparable
         where TTimeStep : IComparable
    {
        public override string[] ColumnHeaders
        {
            get
            {
                return GetColumnHeaders();
            }
        }

        // TODO: don't forget about PanelDirection
        public static string[] GetColumnHeaders()
        {
            return new string[] { "Id", "Name", "Loadcase", "TimeStep", "Node", "AXP", "AXM", "AYP", "AYM" };
        }

        public override ResultType ResultType
        {
            get
            {
                return ResultType.SlabReinforcement;
            }
        }

        public SlabReinforcement()
        {
            Data = new object[9];
        }

        public SlabReinforcement(object[] data) { Data = data; }

        public SlabReinforcement(TName number, TName node, TLoadcase loadcase, TTimeStep timeStep, double axp, double axm, double ayp, double aym) : this()
        {
            Name = number;
            TimeStep = timeStep;
            Loadcase = loadcase;
            Node = node;
            Id = Name + ":" + Node + ":" + loadcase + ":" + TimeStep;
            AXP = axp;
            AXM = axm;
            AYP = ayp;
            AYM = aym;
            //DirX = dirx;
        }

        public TName Node
        {
            get
            {
                return (TName)Data[4];
            }
            set
            {
                Data[4] = value;
            }
        }

        public double AXP
        {
            get
            {
                return (double)Data[5];
            }
            set
            {
                Data[5] = value;
            }
        }
        public double AXM
        {
            get
            {
                return (double)Data[6];
            }
            set
            {
                Data[6] = value;
            }
        }
        public double AYP
        {
            get
            {
                return (double)Data[7];
            }
            set
            {
                Data[7] = value;
            }
        }
        public double AYM
        {
            get
            {
                return (double)Data[8];
            }
            set
            {
                Data[8] = value;
            }
        }

        public override int CompareTo(object obj)
        {
            var r2 = obj as SlabReinforcement<TName, TLoadcase, TTimeStep>;
            if (r2 != null)
            {
                int n = this.Name.CompareTo(r2.Name);
                if (n == 0)
                {
                    int l = this.Loadcase.CompareTo(r2.Loadcase);
                    if (l == 0)
                    {
                        int no = this.Node.CompareTo(r2.Node);
                        return no == 0 ? this.TimeStep.CompareTo(r2.TimeStep) : no;
                    }
                    else
                    {
                        return l;
                    }

                }
                else
                {
                    return n;
                }
            }
            return 1;
        }
    }
}

