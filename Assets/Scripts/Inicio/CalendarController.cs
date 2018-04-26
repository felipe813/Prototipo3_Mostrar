using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalendarController : MonoBehaviour
{
    public GameObject _calendarPanel;
    public Text _yearNumText;
    public Text _monthNumText;

    public GameObject _item;

    public List<GameObject> _dateItems = new List<GameObject>();
    const int _totalDateNum = 42;

    private DateTime _dateTime;
    public static CalendarController _calendarInstance;

    void Start()
    {
        _calendarInstance = this;
        Vector3 startPos = _item.transform.localPosition;
        _dateItems.Clear();
        _dateItems.Add(_item);

        for (int i = 1; i < _totalDateNum; i++)
        {
            GameObject item = GameObject.Instantiate(_item) as GameObject;
            item.name = "Item" + (i + 1).ToString();
            item.transform.SetParent(_item.transform.parent);
            item.transform.localScale = Vector3.one;
            item.transform.localRotation = Quaternion.identity;
            item.transform.localPosition = new Vector3((i % 7) * 51 + startPos.x, startPos.y - (i / 7) * 41, startPos.z);

            _dateItems.Add(item);
        }

        _dateTime = DateTime.Now;

        CreateCalendar();

        _calendarPanel.SetActive(false);
    }

    void CreateCalendar()
    {
        DateTime firstDay = _dateTime.AddDays(-(_dateTime.Day - 1));
        int index = GetDays(firstDay.DayOfWeek);

        int date = 0;
        for (int i = 0; i < _totalDateNum; i++)
        {
            Text label = _dateItems[i].GetComponentInChildren<Text>();
            _dateItems[i].SetActive(false);

            if (i >= index)
            {
                DateTime thatDay = firstDay.AddDays(date);
                if (thatDay.Month == firstDay.Month)
                {
                    _dateItems[i].SetActive(true);

                    label.text = (date + 1).ToString();
                    date++;
                }
            }
        }
        _yearNumText.text = _dateTime.Year.ToString();

        _monthNumText.text = convertMonth(_dateTime.Month);
    }

    private string convertMonth(int month)
    {
        switch (month)
        {
            case 1: return "Enero";
            case 2: return "Febrero";
            case 3: return "Marzo";
            case 4: return "Abril";
            case 5: return "Mayo";
            case 6: return "Junio";
            case 7: return "Julio";
            case 8: return "Agosto";
            case 9: return "Septiembre";
            case 10: return "Octubre";
            case 11: return "Noviembre";
            default: return "Diciembre";
        }
    }

    private string formatDate(string month, string year, string day)
    {
        string retorno = year + "-";
        switch (month)
        {
            case "Enero":
                retorno = retorno + "01";
                break;
            case "Febrero":
                retorno = retorno + "02";
                break;
            case "Marzo":
                retorno = retorno + "03";
                break;
            case "Abril":
                retorno = retorno + "04";
                break;
            case "Mayo":
                retorno = retorno + "05";
                break;
            case "Junio":
                retorno = retorno + "06";
                break;
            case "Julio":
                retorno = retorno + "07";
                break;
            case "Agosto":
                retorno = retorno + "08";
                break;
            case "Septiembre":
                retorno = retorno + "09";
                break;
            case "Octubre":
                retorno = retorno + "10";
                break;
            case "Noviembre":
                retorno = retorno + "11";
                break;
            default:
                retorno = retorno + "12";
                break;
        }
        retorno = retorno + "-";
        if (day.Length == 1)
        {
            retorno = retorno + "0" + day;
        }
        else
        {
            retorno = retorno + day;
        }
        return retorno;
    }

    int GetDays(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Monday: return 1;
            case DayOfWeek.Tuesday: return 2;
            case DayOfWeek.Wednesday: return 3;
            case DayOfWeek.Thursday: return 4;
            case DayOfWeek.Friday: return 5;
            case DayOfWeek.Saturday: return 6;
            case DayOfWeek.Sunday: return 0;
        }

        return 0;
    }
    public void YearPrev()
    {
        _dateTime = _dateTime.AddYears(-1);
        CreateCalendar();
    }

    public void YearNext()
    {
        _dateTime = _dateTime.AddYears(1);
        CreateCalendar();
    }

    public void MonthPrev()
    {
        _dateTime = _dateTime.AddMonths(-1);
        CreateCalendar();
    }

    public void MonthNext()
    {
        _dateTime = _dateTime.AddMonths(1);
        CreateCalendar();
    }

    public void ShowCalendar(Text target)
    {
        _calendarPanel.SetActive(true);
        _target = target;
        _calendarPanel.transform.localPosition = new Vector3(0, 0, 0);//Input.mousePosition-new Vector3(0,120,0);
    }

    Text _target;
    public void OnDateItemClick(string day)
    {
        _target.text = formatDate(_monthNumText.text,_yearNumText.text,day);
        _target.color = Color.black;
        _calendarPanel.SetActive(false);
    }

    public void closeCalendar()
    {
        _calendarPanel.SetActive(false);
    }
}
