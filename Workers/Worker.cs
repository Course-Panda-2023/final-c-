using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Worker
{
    public Zone? CurZone { get; set; }
    public int TotalWorkTime { get; protected set; }
    protected int workedTime;
    public Dictionary<Zone, int> ShiftTime;
    public int PriceChange { get; protected set; }

    public Worker() 
    {
        this.ShiftTime = new Dictionary<Zone, int>();
        this.workedTime = - 130;
    }
    public void StartWorkingDay(object? DoesntMatter)
    {
        this.ChooseShifts();
        //this.ChooseShiftsForBonus();
        workedTime = TotalWorkTime + 1;
        for (int i = 0; i < Zoo.secondsInDay; i++)
        {
            this.WorkForASecond(i);
            Thread.Sleep(Zoo.secondLength);
        }
    }

    private void ChooseShifts()
    {
        Random rnd = new Random();
        foreach (Zone zone in Enum.GetValues(typeof(Zone)))
        {
            this.ShiftTime[zone] = rnd.Next(Zoo.secondsInDay - TotalWorkTime - 1);
        }
        var pairs = (from first in ShiftTime.Values
                     from second in ShiftTime.Values
                     where second > first
                     select new int[] { first, second }).ToArray();
        foreach (int[] pair in pairs)
        {
            if (Math.Abs(pair[0] - pair[1]) < TotalWorkTime)
            {
                this.ChooseShifts();
                break;
            }
        }
    }
    private void ChooseShiftsForBonus()
    {
        Random rnd = new Random();
        int firstShiftTime = rnd.Next(Zoo.secondsInDay - TotalWorkTime - 1);
        int secondShiftTime = rnd.Next(Zoo.secondsInDay - TotalWorkTime - 1);
        if (Math.Abs(firstShiftTime - secondShiftTime) < TotalWorkTime)
            this.ChooseShiftsForBonus();

        Zone firstZone = (Zone)rnd.Next(Enum.GetValues(typeof(Zone)).Length);
        Zone secondZone = (Zone)rnd.Next(Enum.GetValues(typeof(Zone)).Length);

        this.ShiftTime[firstZone] = firstShiftTime;
        this.ShiftTime[secondZone] = secondShiftTime;
    }
    protected void WorkForASecond(int time)
    {
        this.workedTime++;
        if (this.workedTime == this.TotalWorkTime)
        {
            EndShift(time);
        }
        foreach (Zone zone in ShiftTime.Keys)
        {
            if (ShiftTime[zone] == time)
            {
                this.workedTime = 0;
                StartShift(zone, time);
                break;
            }
        }
    }
    protected abstract void EndShift(int time);
    protected abstract void StartShift(Zone zone, int time);
}
