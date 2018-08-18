using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT4Ext
{
    public class MT4ExpertAdvisorBase
    {
        public const int CP_ACP = 0;
        //TODO: check values
        public const int TIME_DATE = 1;
        public const int TIME_MINUTES = 2;
        public const int TIME_SECONDS = 4;
        public const int DOUBLE_VALUE = 8;
        public const int FLOAT_VALUE = 4;
        public const int INT_VALUE = 4;

        public struct datetime
        {
            public long value;
        }
        public struct MqlTick
        {
            public datetime time;          // Time of the last prices update 
            public double bid;           // Current Bid price 
            public double ask;           // Current Ask price 
            public double last;          // Price of the last deal (Last) 
            public ulong volume;        // Volume for the current Last price 
        }
        public struct MqlRates
        {
            public datetime time;         // Period start time 
            public double open;         // Open price 
            public double high;         // The highest price of the period 
            public double low;          // The lowest price of the period 
            public double close;        // Close price 
            public long tick_volume;  // Tick volume 
            public int spread;       // Spread 
            public long real_volume;  // Trade volume 
        }
        public struct MqlDateTime
        {
            public int year;           // Year 
            public int mon;            // Month 
            public int day;            // Day 
            public int hour;           // Hour 
            public int min;            // Minutes 
            public int sec;            // Seconds 
            public int day_of_week;    // Day of week (0-Sunday, 1-Monday, ... ,6-Saturday) 
            public int day_of_year;    // Day number of the year (January 1st is assigned the number value of zero) 
        }
        public enum ENUM_SERIES_INFO_INTEGER
        {
            SERIES_BARS_COUNT,//Bars count for the symbol - period for the current moment long
            SERIES_FIRSTDATE,//The very first date for the symbol - period for the current moment datetime
            SERIES_LASTBAR_DATE,//Open time of the last bar of the symbol - period datetime
            SERIES_SERVER_FIRSTDATE,//The very first date in the history of the symbol on the server regardless of the timeframe datetime
        }
        public enum ENUM_DAY_OF_WEEK
        {
            SUNDAY,//Sunday
            MONDAY,//Monday
            TUESDAY,//Tuesday
            WEDNESDAY,//Wednesday
            THURSDAY,//Thursday
            FRIDAY,//Friday
            SATURDAY,//Saturday
        }
        public enum ENUM_TIMEFRAMES
        {
            PERIOD_CURRENT = 0,//0 Current timeframe
            PERIOD_M1 = 1,//1 1 minute
            PERIOD_M5 = 5,//5 5 minutes
            PERIOD_M15 = 15,//15 15 minutes
            PERIOD_M30 = 30,//30 30 minutes
            PERIOD_H1 = 60,//60 1 hour
            PERIOD_H4 = 240,//240 4 hours
            PERIOD_D1 = 1440,//1440 1 day
            PERIOD_W1 = 10080,//10080 1 week
            PERIOD_MN1 = 43200,//43200 1 month

            PERIOD_M2 = 2,//2 2 minutes
            PERIOD_M3 = 3,//3 3 minutes
            PERIOD_M4 = 4,//4 4 minutes
            PERIOD_M6 = 6,//6 6 minutes
            PERIOD_M10 = 10,//10 10 minutes
            PERIOD_M12 = 12,//12 12 minutes
            PERIOD_M20 = 20,//20 20 minutes
            PERIOD_H2 = 120,//120 2 hours
            PERIOD_H3 = 180,//180 3 hours
            PERIOD_H6 = 360,//360 6 hours
            PERIOD_H8 = 480,//480 8 hours
            PERIOD_H12 = 720, //720 12 hours
        }
        public enum ENUM_COLOR_FORMAT
        {
            COLOR_FORMAT_XRGB_NOALPHA,//The component of the alpha channel is ignored
            COLOR_FORMAT_ARGB_RAW,//Color components are not handled by the terminal(must be correctly set by the user)
            COLOR_FORMAT_ARGB_NORMALIZE,//Color components are handled by the terminal
        }
        public enum ENUM_STATISTICS
        {
            STAT_INITIAL_DEPOSIT,//The value of the initial deposit double
            STAT_PROFIT,//Net profit after testing, the sum of STAT_GROSS_PROFIT and STAT_GROSS_LOSS(STAT_GROSS_LOSS is always less than or equal to zero) double
            STAT_GROSS_PROFIT,//Total profit, the sum of all profitable(positive) trades.The value is greater than or equal to zero double
            STAT_GROSS_LOSS,//Total loss, the sum of all negative trades.The value is less than or equal to zero double
            STAT_MAX_PROFITTRADE,//Maximum profit – the largest value of all profitable trades.The value is greater than or equal to zero double
            STAT_MAX_LOSSTRADE,//Maximum loss – the lowest value of all losing trades.The value is less than or equal to zero double
            STAT_CONPROFITMAX,//Maximum profit in a series of profitable trades.The value is greater than or equal to zero double
            STAT_CONPROFITMAX_TRADES,//The number of trades that have formed STAT_CONPROFITMAX(maximum profit in a series of profitable trades) int
            STAT_MAX_CONWINS,//The total profit of the longest series of profitable trades double
            STAT_MAX_CONPROFIT_TRADES,//The number of trades in the longest series of profitable trades STAT_MAX_CONWINS int
            STAT_CONLOSSMAX,//Maximum loss in a series of losing trades.The value is less than or equal to zero double
            STAT_CONLOSSMAX_TRADES,//The number of trades that have formed STAT_CONLOSSMAX(maximum loss in a series of losing trades) int
            STAT_MAX_CONLOSSES,//The total loss of the longest series of losing trades double
            STAT_MAX_CONLOSS_TRADES,//The number of trades in the longest series of losing trades STAT_MAX_CONLOSSES int
            STAT_BALANCEMIN,//Minimum balance value double
            STAT_BALANCE_DD,//Maximum balance drawdown in monetary terms.In the process of trading, a balance may have numerous drawdowns; here the largest value is taken double
            STAT_BALANCEDD_PERCENT,//Balance drawdown as a percentage that was recorded at the moment of the maximum balance drawdown in monetary terms(STAT_BALANCE_DD). double
            STAT_BALANCE_DDREL_PERCENT,//Maximum balance drawdown as a percentage.In the process of trading, a balance may have numerous drawdowns, for each of which the relative drawdown value in percents is calculated.The greatest value is returned double
            STAT_BALANCE_DD_RELATIVE,//Balance drawdown in monetary terms that was recorded at the moment of the maximum balance drawdown as a percentage(STAT_BALANCE_DDREL_PERCENT). double
            STAT_EQUITYMIN,//Minimum equity value double
            STAT_EQUITY_DD,//Maximum equity drawdown in monetary terms.In the process of trading, numerous drawdowns may appear on the equity; here the largest value is taken double
            STAT_EQUITYDD_PERCENT,//Drawdown in percent that was recorded at the moment of the maximum equity drawdown in monetary terms(STAT_EQUITY_DD). double
            STAT_EQUITY_DDREL_PERCENT,//Maximum equity drawdown as a percentage.In the process of trading, an equity may have numerous drawdowns, for each of which the relative drawdown value in percents is calculated.The greatest value is returned double
            STAT_EQUITY_DD_RELATIVE,//Equity drawdown in monetary terms that was recorded at the moment of the maximum equity drawdown in percent(STAT_EQUITY_DDREL_PERCENT). double
            STAT_EXPECTED_PAYOFF,//Expected payoff double
            STAT_PROFIT_FACTOR,//Profit factor, equal to  the ratio of STAT_GROSS_PROFIT / STAT_GROSS_LOSS.If STAT_GROSS_LOSS = 0, the profit factor is equal to DBL_MAX double
            STAT_MIN_MARGINLEVEL,//Minimum value of the margin level double
            STAT_CUSTOM_ONTESTER,//The value of the calculated custom optimization criterion returned by the OnTester() function double
            STAT_TRADES,//The number of trades int
            STAT_PROFIT_TRADES,//Profitable trades int
            STAT_LOSS_TRADES,//Losing trades int
            STAT_SHORT_TRADES,//Short trades int
            STAT_LONG_TRADES,//Long trades int
            STAT_PROFIT_SHORTTRADES,//Profitable short trades int
            STAT_PROFIT_LONGTRADES,//Profitable long trades int
            STAT_PROFITTRADES_AVGCON,//Average length of a profitable series of trades int
            STAT_LOSSTRADES_AVGCON,//Average length of a losing series of trades int
        }
        public enum ENUM_SYMBOL_INFO_DOUBLE
        {
            SYMBOL_BID,//Bid - best sell offer double
            SYMBOL_BIDHIGH,//Not supported double
            SYMBOL_BIDLOW,//Not supported double
            SYMBOL_ASK,//Ask - best buy offer double
            SYMBOL_ASKHIGH,//Not supported double
            SYMBOL_ASKLOW,//Not supported double
            SYMBOL_LAST,//Not supported double
            SYMBOL_LASTHIGH,//Not supported double
            SYMBOL_LASTLOW,//Not supported double
            SYMBOL_POINT,//Symbol point value double
            SYMBOL_TRADE_TICK_VALUE,//Value of SYMBOL_TRADE_TICK_VALUE_PROFIT double
            SYMBOL_TRADE_TICK_VALUE_PROFIT,//Not supported double
            SYMBOL_TRADE_TICK_VALUE_LOSS,//Not supported double
            SYMBOL_TRADE_TICK_SIZE,//Minimal price change double
            SYMBOL_TRADE_CONTRACT_SIZE,//Trade contract size double
            SYMBOL_VOLUME_MIN,//Minimal volume for a deal double
            SYMBOL_VOLUME_MAX,//Maximal volume for a deal double
            SYMBOL_VOLUME_STEP,//Minimal volume change step for deal execution double
            SYMBOL_VOLUME_LIMIT,//Not supported double
            SYMBOL_SWAP_LONG,//Buy order swap value double
            SYMBOL_SWAP_SHORT,//Sell order swap value double
            SYMBOL_MARGIN_INITIAL,//Initial margin means the amount in the margin currency required for opening an order with the volume of one lot.It is used for checking a client's assets when he or she enters the market. double
            SYMBOL_MARGIN_MAINTENANCE,//The maintenance margin.If it is set, it sets the margin amount in the margin currency of the symbol, charged from one lot.It is used for checking a client's assets when his/her account state changes. If the maintenance margin is equal to 0, the initial margin is used. double
            SYMBOL_MARGIN_LONG,//Not supported double
            SYMBOL_MARGIN_SHORT,//Not supported double
            SYMBOL_MARGIN_LIMIT,//Not supported double
            SYMBOL_MARGIN_STOP,//Not supported double
            SYMBOL_MARGIN_STOPLIMIT,//Not supported double
            SYMBOL_SESSION_VOLUME,//Not supported double
            SYMBOL_SESSION_TURNOVER,//Not supported double
            SYMBOL_SESSION_INTEREST,//Not supported double
            SYMBOL_SESSION_BUY_ORDERS_VOLUME,//Not supported double
            SYMBOL_SESSION_SELL_ORDERS_VOLUME,//Not supported double
            SYMBOL_SESSION_OPEN,//Not supported double
            SYMBOL_SESSION_CLOSE,//Not supported double
            SYMBOL_SESSION_AW,//Not supported double
            SYMBOL_SESSION_PRICE_SETTLEMENT,//Not supported double
            SYMBOL_SESSION_PRICE_LIMIT_MIN,//Not supported double
            SYMBOL_SESSION_PRICE_LIMIT_MAX,//Not supported double
        }
        public enum ENUM_SYMBOL_INFO_INTEGER
        {
            SYMBOL_SELECT,//Symbol is selected in Market Watch. Some symbols can be hidden in Market Watch, but still they are considered as selected. bool
            SYMBOL_VISIBLE,//Symbol is visible in Market Watch.Some symbols(mostly, these are cross rates required for calculation of margin requirements or profits in deposit currency) are selected automatically, but generally are not visible in Market Watch.To be displayed such symbols have to be explicitly selected. bool
            SYMBOL_SESSION_DEALS,//Not supported long
            SYMBOL_SESSION_BUY_ORDERS,//Not supported long
            SYMBOL_SESSION_SELL_ORDERS,//Not supported long
            SYMBOL_VOLUME,//Not supported long
            SYMBOL_VOLUMEHIGH,//Not supported long
            SYMBOL_VOLUMELOW,//Not supported long
            SYMBOL_TIME,//Time of the last quote datetime
            SYMBOL_DIGITS,//Digits after a decimal point int
            SYMBOL_SPREAD_FLOAT,//Indication of a floating spread bool
            SYMBOL_SPREAD,//Spread value in points int
            SYMBOL_TRADE_CALC_MODE,//Contract price calculation mode int
            SYMBOL_TRADE_MODE,//Order execution type ENUM_SYMBOL_TRADE_MODE
            SYMBOL_START_TIME,//Date of the symbol trade beginning(usually used for futures) datetime
            SYMBOL_EXPIRATION_TIME,//Date of the symbol trade end(usually used for futures) datetime
            SYMBOL_TRADE_STOPS_LEVEL,//Minimal indention in points from the current close price to place Stop orders int
            SYMBOL_TRADE_FREEZE_LEVEL,//Distance to freeze trade operations in points int
            SYMBOL_TRADE_EXEMODE,//Deal execution mode ENUM_SYMBOL_TRADE_EXECUTION
            SYMBOL_SWAP_MODE,//Swap calculation model int
            SYMBOL_SWAP_ROLLOVER3DAYS,//Day of week to charge 3 days swap rollover ENUM_DAY_OF_WEEK
            SYMBOL_EXPIRATION_MODE,//Not supported int
            SYMBOL_FILLING_MODE,//Not supported int
            SYMBOL_ORDER_MODE,//Not supported int
        }
        public enum ENUM_SYMBOL_INFO_STRING
        {
            SYMBOL_CURRENCY_BASE,//Basic currency of a symbol string
            SYMBOL_CURRENCY_PROFIT,//Profit currency string
            SYMBOL_CURRENCY_MARGIN,//Margin currency string
            SYMBOL_DESCRIPTION,//Symbol description string
            SYMBOL_PATH,//Path in the symbol tree string
        }
        public enum ENUM_ALIGN_MODE
        {
            ALIGN_LEFT,//Left alignment
            ALIGN_CENTER,//Centered(only for the Edit object)
            ALIGN_RIGHT,//Right alignment
        }
        public enum ENUM_FILE_PROPERTY_INTEGER
        {
            FILE_EXISTS,//Check the existence
            FILE_CREATE_DATE,//Date of creation
            FILE_MODIFY_DATE,//Date of the last modification
            FILE_ACCESS_DATE,//Date of the last access to the file
            FILE_SIZE,//File size in bytes
            FILE_POSITION,//Position of a pointer in the file
            FILE_END_,//Get the end of file sign
            FILE_LINE_END,//Get the end of line sign
            FILE_IS_COMMON,//The file is opened in a shared folder of all terminals(see FILE_COMMON)
            FILE_IS_TEXT,//The file is opened as a text file(see FILE_TXT)
            FILE_IS_BINARY,//The file is opened as a binary file(see FILE_BIN)
            FILE_IS_CSV,//The file is opened as CSV(see FILE_CSV)
            FILE_IS_ANSI,//The file is opened as ANSI(see FILE_ANSI)
            FILE_IS_READABLE,//The opened file is readable(see FILE_READ)
            FILE_IS_WRITABLE,//The opened file is writable(see FILE_WRITE)
        }
        public enum ENUM_SIGNAL_BASE_DOUBLE
        {
            SIGNAL_BASE_BALANCE,//Account balance
            SIGNAL_BASE_EQUITY,//Account equity
            SIGNAL_BASE_GAIN,//Account gain
            SIGNAL_BASE_MAX_DRAWDOWN,//Account maximum drawdown
            SIGNAL_BASE_PRICE,//Signal subscription price
            SIGNAL_BASE_ROI,//Return on Investment(%)
        }
        public enum ENUM_SIGNAL_BASE_INTEGER
        {
            SIGNAL_BASE_DATE_PUBLISHED,//Publication date(date when it become available for subscription)
            SIGNAL_BASE_DATE_STARTED,//Monitoring starting date
            SIGNAL_BASE_ID,//Signal ID
            SIGNAL_BASE_LEVERAGE,//Account leverage
            SIGNAL_BASE_PIPS,//Profit in pips
            SIGNAL_BASE_RATING,//Position in rating
            SIGNAL_BASE_SUBSCRIBERS,//Number of subscribers
            SIGNAL_BASE_TRADES,//Number of trades
            SIGNAL_BASE_TRADE_MODE,//Account type(0 - real, 1 - demo, 2 - contest)
        }
        public enum ENUM_SIGNAL_BASE_STRING
        {
            SIGNAL_BASE_AUTHOR_LOGIN,//Author login
            SIGNAL_BASE_BROKER,//Broker name(company)
            SIGNAL_BASE_BROKER_SERVER,//Broker server
            SIGNAL_BASE_NAME,//Signal name
            SIGNAL_BASE_CURRENCY,//Signal base currency
        }
        public enum ENUM_SIGNAL_INFO_DOUBLE
        {
            SIGNAL_INFO_EQUITY_LIMIT,//Minimum equity value, below which trade copying is stopped automatically and all orders opened by subscription are closed
            SIGNAL_INFO_SLIPPAGE,//Allowable subscription when copying deals, in spreads
            SIGNAL_INFO_VOLUME_PERCENT,//Percentage of volume conversion when copying deals, r / o
        }
        public enum ENUM_SIGNAL_INFO_INTEGER
        {
            SIGNAL_INFO_CONFIRMATIONS_DISABLED,//The flag enables synchronization without confirmation dialog
            SIGNAL_INFO_COPY_SLTP,//Copy Stop Loss and Take Profit flag
            SIGNAL_INFO_DEPOSIT_PERCENT,//Percentage of trading account funds used when following providers' signals (in %)
            SIGNAL_INFO_ID,//Signal id, r / o
            SIGNAL_INFO_SUBSCRIPTION_ENABLED,//"Copy trades by subscription" permission flag
            SIGNAL_INFO_TERMS_AGREE,//"Agree to terms of use of Signals service" flag, r / o
        }
        public enum ENUM_SIGNAL_INFO_STRING
        {
            SIGNAL_INFO_NAME
        }
        //Object Functions:
        public enum ENUM_OBJECT
        {
            OBJ_VLINE,//vertical_line Vertical Line
            OBJ_HLINE,//horizonal_line Horizontal Line
            OBJ_TREND,//trend_line Trend Line
            OBJ_TRENDBYANGLE,//trend_line)by_angle Trend Line By Angle
            OBJ_CYCLES,//cycle_lines Cycle Lines
            OBJ_CHANNEL,//equidistance_channel Equidistant Channel
            OBJ_STDDEVCHANNEL,//stddeviation_channel Standard Deviation Channel
            OBJ_REGRESSION,//regression_channel Linear Regression Channel
            OBJ_PITCHFORK,//andrewspitchfork Andrews’ Pitchfork
            OBJ_GANNLINE,//gann_line Gann Line
            OBJ_GANNFAN,//gann_fan Gann Fan
            OBJ_GANNGRID,//gann_grid Gann Grid
            OBJ_FIBO,//fibonacci_levels Fibonacci Retracement
            OBJ_FIBOTIMES,//fibonacci_time_zones Fibonacci Time Zones
            OBJ_FIBOFAN,//fibo_fan Fibonacci Fan
            OBJ_FIBOARC,//fibo_arc Fibonacci Arcs
            OBJ_FIBOCHANNEL,//fibo_channel Fibonacci Channel
            OBJ_EXPANSION,//fibo_expansion Fibonacci Expansion
            OBJ_RECTANGLE,//rectangle Rectangle
            OBJ_TRIANGLE,//triangle Triangle
            OBJ_ELLIPSE,//ellipse Ellipse
            OBJ_ARROW_THUMB_UP,//THUMB_UP Thumbs Up
            OBJ_ARROW_THUMB_DOWN,//THUMB_DOWN Thumbs Down
            OBJ_ARROW_UP,//arrow_up Arrow Up
            OBJ_ARROW_DOWN,//arrow_downArrow Down
            OBJ_ARROW_STOP,//stop_signal Stop Sign
            OBJ_ARROW_CHECK,//check_signal Check Sign
            OBJ_ARROW_LEFT_PRICE,//left_price_label Left Price Label
            OBJ_ARROW_RIGHT_PRICE,//right_price_label Right Price Label
            OBJ_ARROW_BUY,//buy_sign_icon Buy Sign
            OBJ_ARROW_SELL,//sell_sign_icon Sell Sign
            OBJ_ARROW,//arrow_symbol Arrow
            OBJ_TEXT,//text_object Text
            OBJ_LABEL,//label_object Label
            OBJ_BUTTON,//button_object Button
            OBJ_BITMAP_,//picture_object Bitmap
            OBJ_BITMAP_LABEL,//bitmap_object Bitmap Label
            OBJ_EDIT,//edit_object Edit
            OBJ_EVENT,//obj_event The "Event" object corresponding to an event in the economic calendar
            OBJ_RECTANGLE_LABEL,//rectangle_label The "Rectangle label" object for creating and designing the custom graphical interface.
        }
        public enum ENUM_POINTER_TYPE
        {
            POINTER_INVALID,//Incorrect pointer
            POINTER_DYNAMIC,//Pointer of the object created by the new() operator
            POINTER_AUTOMATIC
        }
        public enum ENUM_CRYPT_METHOD
        {
            CRYPT_BASE64,//BASE64
            CRYPT_AES128,//AES encryption with 128 bit key(16 bytes)
            CRYPT_AES256,//AES encryption with 256 bit key(32 bytes)
            CRYPT_DES,//DES encryption with 56 bit key(7 bytes)
            CRYPT_HASH_SHA1,//SHA1 HASH calculation
            CRYPT_HASH_SHA256,//SHA256 HASH calculation
            CRYPT_HASH_MD5,//MD5 HASH calculation
            CRYPT_ARCH_ZIP,//ZIP archives
        }
        public enum ENUM_INDEXBUFFER_TYPE
        {

        }
        public enum ENUM_MARKET_INFO_MODE
        {
            MODE_LOW = 1,//1 Low day price
            MODE_HIGH = 2,//2 High day price
            MODE_TIME = 5,//5 The last incoming tick time(last known server time)
            MODE_BID = 9,//9 Last incoming bid price.For the current symbol, it is stored in the predefined variable Bid
            MODE_ASK = 10,//10 Last incoming ask price.For the current symbol, it is stored in the predefined variable Ask
            MODE_POINT = 11,//11 Point size in the quote currency.For the current symbol, it is stored in the predefined variable Point
            MODE_DIGITS = 12,//12 Count of digits after decimal point in the symbol prices.For the current symbol, it is stored in the predefined variable Digits
            MODE_SPREAD = 13,//13 Spread value in points
            MODE_STOPLEVEL = 14,//14 Stop level in points A zero value of MODE_STOPLEVEL means either absence of any restrictions on the minimal distance for Stop Loss / Take Profit or the fact that a trade server utilizes some external mechanisms for dynamic level control, which cannot be translated in the client terminal.In the second case, GetLastError() can return error 130, because MODE_STOPLEVEL is actually "floating" here.
            MODE_LOTSIZE = 15,//15 Lot size in the base currency
            MODE_TICKVALUE = 16,//16 Tick value in the deposit currency
            MODE_TICKSIZE = 17,//17 Tick size in points
            MODE_SWAPLONG = 18,//18 Swap of the buy order
            MODE_SWAPSHORT = 19,//19 Swap of the sell order
            MODE_STARTING = 20,//20 Market starting date(usually used for futures)
            MODE_EXPIRATION = 21,//21 Market expiration date(usually used for futures)
            MODE_TRADEALLOWED = 22,//22 Trade is allowed for the symbol
            MODE_MINLOT = 23,//23 Minimum permitted amount of a lot
            MODE_LOTSTEP = 24,//24 Step for changing lots
            MODE_MAXLOT = 25,//25 Maximum permitted amount of a lot
            MODE_SWAPTYPE = 26,//26 Swap calculation method. 0 - in points; 1 - in the symbol base currency; 2 - by interest; 3 - in the margin currency
            MODE_PROFITCALCMODE = 27,//27 Profit calculation mode. 0 - Forex; 1 - CFD; 2 - Futures
            MODE_MARGINCALCMODE = 28,//28 Margin calculation mode. 0 - Forex; 1 - CFD; 2 - Futures; 3 - CFD for indices
            MODE_MARGININIT = 29,//29 Initial margin requirements for 1 lot
            MODE_MARGINMAINTENANCE = 30,//30 Margin to maintain open orders calculated for 1 lot
            MODE_MARGINHEDGED = 31,//31 Hedged margin calculated for 1 lot
            MODE_MARGINREQUIRED = 32,//32 Free margin required to open 1 lot for buying
            MODE_FREEZELEVEL = 33,//33 Order freeze level in points.If the execution price lies within the range defined by the freeze level, the order cannot be modified, cancelled or closed
            MODE_CLOSEBY_ALLOWED = 34,//34 Allowed using OrderCloseBy() to close opposite orders on a specified symbol
        }


        //Variables
        public int _RandomSeed => GetRandomSeed();
        public double _Digits => Digits();
        public double _Point => Point();
        public int _LastError => GetLastError();
        public int _Period => Period();
        public bool _StopFlag => IsStopped();
        public string _Symbol => Symbol();
        public int _UninitReason => UninitializeReason();
        public double Ask => MarketInfo(Symbol(), ENUM_MARKET_INFO_MODE.MODE_ASK);
        public double Bid => MarketInfo(Symbol(), ENUM_MARKET_INFO_MODE.MODE_BID);
        public int _Bars => iBars(Symbol(), ENUM_TIMEFRAMES.PERIOD_CURRENT);

        public int GetRandomSeed() => 0;


        //Events
        public bool EventSetMillisecondTimer(
            int milliseconds      // number of milliseconds 
        )
        {
            return false;
        }

        public bool EventSetTimer(
            int seconds      // number of seconds 
        )
        {
            return false;
        }

        public void EventKillTimer()
        {

        }

        public bool EventChartCustom(
            long chart_id,            // identifier of the event receiving chart 
            ushort custom_event_id,     // event identifier 
            long lparam,              // parameter of type long 
            double dparam,              // parameter of type double 
            string sparam               // string parameter of the event 
        )
        {
            return false;
        }
        //Common Functions
        public void Alert(
            string argument,     // first value 
            params object[] args           // other values 
            )
        {

        }



        public ENUM_POINTER_TYPE CheckPointer(
            object anyobject      // object pointer 
        )
        {
            return default(ENUM_POINTER_TYPE);
        }

        public void Comment(
            string argument,     // first value 
            params object[] args
        )
        {
        }


        public int CryptEncode(
            ENUM_CRYPT_METHOD method,        // method 
            byte[]/*&*/        data,        // source array 
            byte[]/*&*/        key,         // key 
            byte[]/*&*/         result       // destination array 
        )
        {
            return 0;
        }
        public int CryptDecode(
            ENUM_CRYPT_METHOD method,        // method 
            byte[]/*&*/        data,        // source array 
            byte[]/*&*/        key,         // key 
            byte[]/*&*/         result       // destination array 
        )
        {
            return 0;
        }

        public void DebugBreak()
        {

        }

        public void ExpertRemove()
        {

        }

        public object GetPointer(
            object anyobject      // object of any class 
        )
        {
            return anyobject;
        }

        public uint GetTickCount()
        {
            return 0;
        }

        public ulong GetMicrosecondCount()
        {
            return 0;
        }

        public int MessageBox(
            string text,             // message text 
            string caption = null,     // box header 
            int flags = 0           // defines set of buttons in the box 
        )
        {
            return 0;
        }

        public int PeriodSeconds(
            ENUM_TIMEFRAMES period = ENUM_TIMEFRAMES.PERIOD_CURRENT      // chart period 
        )
        {
            return 0;
        }

        public bool PlaySound(
            string filename      // file name 
        )
        {
            return false;
        }
        public void Print(
            string argument,     // first value 
            params object[] args
        )
        { }

        public void PrintFormat(
            string format_string,   // format string 
            params object[] args
        )
        {
        }

        public void ResetLastError()
        {

        }


        public bool ResourceCreate(
            string resource_name,       // Resource name 
            string path                 // A relative path to the file 
        )
        {
            return false;
        }

        public bool ResourceCreate(
            string resource_name,       // Resource name 
            uint[]/*&*/       data,              // Data set as an array 
            uint img_width,           // The width of the image resource 
            uint img_height,          // The height of the image resource 
            uint data_xoffset,        // The horizontal rightward offset of the upper left corner of the image 
            uint data_yoffset,        // The vertical downward offset of the upper left corner of the image 
            uint data_width,          // The total width of the image based on the data set 
            ENUM_COLOR_FORMAT color_format         // Color processing method 
        )
        {
            return false;
        }
        public bool ResourceFree(
            string resource_name      // resource name 
        )
        {
            return false;
        }
        public bool ResourceReadImage(
             string resource_name,       // graphical resource name for reading 
             uint[]/*&*/             data,              // array for receiving data from the resource 
             ref uint width,               // for receiving the image width in the resource 
             ref uint height               // for receiving the image height in the resource 
         )
        {
            return false;
        }

        public bool ResourceSave(
             string resource_name,     // Resource name 
             string file_name          // File name 
        )
        {
            return false;
        }

        public void SetUserError(
            ushort user_error   // error number 
        )
        {

        }

        public bool SendFTP(
            string filename,          // file to be send by ftp 
            string ftp_path = null      // ftp catalog 
        )
        {
            return false;
        }

        public bool SendNotification(
            string text          // Text of the notification 
        )
        {
            return false;
        }


        public bool SendMail(
            string subject,       // header 
            string some_text      // email text 
        )
        {
            return false;
        }

        public void Sleep(
            int milliseconds      // interval 
        )
        {

        }

        public bool TerminalClose(
            int ret_code      // closing code of the client terminal 
        )
        {
            return false;
        }


        public double TesterStatistics(
            ENUM_STATISTICS statistic_id      // ID 
        )
        {
            return 0.0;
        }

        public short TranslateKey(
            int key_code      // key code for receiving a Unicode character 
        )
        {
            return 0;
        }

        public int WebRequest(
            string method,           // HTTP method  
            string url,              // URL 
            string cookie,           // cookie 
            string referer,          // referer 
            int timeout,          // timeout 
            byte[]/*&*/   data,          // the array of the HTTP message body 
            int data_size,        // data[] array size in bytes 
            byte[]/*&*/         result,        // an array containing server response data 
            ref string result_headers   // headers of server response 
        )
        {
            return 0;
        }

        public int WebRequest(
            string method,           // HTTP method 
            string url,              // URL 
            string headers,          // headers  
            int timeout,          // timeout 
            byte[]/*&*/   data,          // the array of the HTTP message body 
            byte[]/*&*/         result,        // an array containing server response data 
            ref string result_headers   // headers of server response 
        )
        {
            return 0;
        }

        public void ZeroMemory(
            object variable      // reset variable 
        )
        {

        }
        //NOTICE: values maybe wrong
        public const int WHOLE_ARRAY = 0;
        public const int MODE_ASCEND = +1;
        public const int MODE_DESCEND = -1;
        public const int EMPTY = -1;

        //Array Functions
        public int ArrayBsearch(
            double[]/*&*/   array,               // array for search 
            double value,                 // what is searched for 
            int count = WHOLE_ARRAY,     // count of elements to search for 
            int start = 0,               // starting position 
            int direction = MODE_ASCEND  // search direction 
        )
        {
            return 0;
        }
        public int ArrayBsearch(
            float[]/*&*/    array,               // array for search 
            float value,                 // what is searched for 
            int count = WHOLE_ARRAY,     // count of elements to search for 
            int start = 0,               // starting position 
            int direction = MODE_ASCEND  // search direction 
        )
        {
            return 0;
        }
        public int ArrayBsearch(
            long[]/*&*/    array,               // array for search 
            long value,                 // what is searched for 
            int count = WHOLE_ARRAY,     // count of elements to search for 
            int start = 0,               // starting position 
            int direction = MODE_ASCEND  // search direction 
        )
        {
            return 0;
        }

        public int ArrayBsearch(
            int[]/*&*/   array,               // array for search 
            int value,                 // what is searched for 
            int count = WHOLE_ARRAY,     // count of elements to search for 
            int start = 0,               // starting position 
            int direction = MODE_ASCEND  // search direction 
        )
        {
            return 0;
        }

        public int ArrayBsearch(
            short[]/*&*/   array,               // array for search 
            short value,                 // what is searched for 
            int count = WHOLE_ARRAY,     // count of elements to search for 
            int start = 0,               // starting position 
            int direction = MODE_ASCEND  // search direction 
        )
        {
            return 0;
        }

        public int ArrayBsearch(
                byte[]/*&*/    array,               // array for search 
                byte value,                 // what is searched for 
                int count = WHOLE_ARRAY,     // count of elements to search for 
                int start = 0,               // starting position 
                int direction = MODE_ASCEND  // search direction 
            )
        {
            return 0;
        }

        public int ArrayCopy(
            object[]/*&*/        dst_array/*[]*/,         // destination array 
            object[]/*&*/  src_array/*[]*/,         // source array 
            int dst_start = 0,         // index starting from which write into destination array 
            int src_start = 0,         // first index of a source array 
            int count = WHOLE_ARRAY    // number of elements 
        )
        {
            return 0;
        }

        public int ArrayCompare(
            object[]/*&*/  array1/*[]*/,            // first array 
            object[]/*&*/  array2/*[]*/,            // second array 
            int start1 = 0,            // initial offset in the first array 
            int start2 = 0,            // initial offset in the second array 
            int count = WHOLE_ARRAY    // number of elements for comparison 
        )
        {
            return 0;
        }
        public void ArrayFree(
            object[]/*&*/  array/*[]*/      // array 
        )
        {
        }

        public bool ArrayGetAsSeries(
            object[]/*&*/  array/*[]*/    // array for checking 
        )
        {
            return false;
        }
        public int ArrayInitialize(
            char[] array,     // initialized array 
            char value        // value that will be set 
        )
        {
            return 0;
        }
        public int ArrayInitialize(
            short[] array,     // initialized array 
            short value        // value that will be set 
        )
        {
            return 0;
        }
        public int ArrayInitialize(
            int[] array,     // initialized array 
            int value        // value that will be set 
        )
        {
            return 0;
        }
        public int ArrayInitialize(
            long[] array,     // initialized array 
            long value        // value that will be set 
        )
        {
            return 0;
        }

        public int ArrayInitialize(
            float[] array,     // initialized array 
            float value        // value that will be set 
        )
        {
            return 0;
        }
        public int ArrayInitialize(
            double[] array,     // initialized array 
            double value        // value that will be set 
        )
        {
            return 0;
        }
        public int ArrayInitialize(
            bool[] array,     // initialized array 
            bool value        // value that will be set 
        )
        {
            return 0;
        }
        public int ArrayInitialize(
            uint[] array,     // initialized array 
            uint value        // value that will be set 
        )
        {
            return 0;
        }
        public void ArrayFill(
            object[]/*&*/  array/*[]*/,      // array 
            int start,        // starting index 
            int count,        // number of elements to fill 
            object value         // value 
        )
        {

        }
        public bool ArrayIsDynamic(
            object[]/*&*/  array/*[]*/    // checked array 
        )
        {
            return false;
        }
        public bool ArrayIsSeries(
            object[]/*&*/  array/*[]*/    // checked array 
        )
        {
            return false;
        }

        public int ArrayMaximum(
            object[]/*&*/  array/*[]*/,             // array for search 
            int count = WHOLE_ARRAY,   // number of checked elements 
            int start = 0              // index to start checking with 
        )
        {
            return 0;
        }

        public int ArrayMinimum(
            object[]/*&*/  array/*[]*/,             // array for search 
            int count = WHOLE_ARRAY,   // number of checked elements 
            int start = 0              // index to start checking with 
        )
        {
            return 0;
        }
        public int ArrayRange(
            object[]/*&*/  array/*[]*/,      // array for check 
            int rank_index    // index of dimension 
        )
        {
            return 0;
        }

        public int ArrayResize(
            object[]/*&*/  array/*[]*/,              // array passed by reference 
            int new_size,             // new array size 
            int reserve_size = 0        // reserve size value (excess) 
        )
        {
            return 0;
        }
        public bool ArraySetAsSeries(
            object[]/*&*/  array/*[]*/,    // array by reference 
            bool flag        // true denotes reverse order of indexing 
        )
        {
            return false;
        }

        public int ArraySize(
            object[]/*&*/  array/*[]*/   // checked array 
        )
        {
            return 0;
        }
        public bool ArraySort(
            object[]/*&*/  array/*[]*/,                // array for sorting 
            int count = WHOLE_ARRAY,      // count 
            int start = 0,                // starting index 
            int direction = MODE_ASCEND   // sort direction 
        )
        {
            return false;
        }

        public int ArrayCopyRates(
            MqlRates[]/*&*/  rates_array/*[]*/,   // MqlRates array, passed by reference 
            string symbol = null,     // symbol 
            int timeframe = 0      // timeframe 
        )
        {
            return 0;
        }
        //public int ArrayCopyRates(
        //    void**/*&*/     dest_array/*[][]*/,    // destination array, passed by reference 
        //    string symbol = null,       // symbol 
        //    int timeframe = 0        // timeframe 
        //)
        //{
        //    return 0;
        //}
        public int ArrayCopySeries(
            object[]/*&*/  array/*[]*/,           // destination array 
            int series_index,      // series array identifier 
            string symbol = null,       // symbol 
            int timeframe = 0        // timeframe 
        )
        {
            return 0;
        }
        public int ArrayDimension(
            object[]/*&*/  array/*[]*/           // array 
        )
        {
            return 0;
        }

        //Conversions
        public string CharToString(
            char char_code      // numeric code of symbol 
        )
        {
            return null;
        }

        public string CharArrayToString(
            char[] array,              // array 
            int start = 0,              // starting position in the array 
            int count = -1,             // number of symbols 
            int codepage = CP_ACP       // code page 
        )
        {
            return null;
        }
        public uint ColorToARGB(
            int clr,          // converted color in color format 
            byte alpha = 255     // alpha channel managing color transparency 
        )
        {
            return 0;
        }

        public string ColorToString(
            int color_value,     // color value 
            bool color_name       // show color name or not 
        )
        {
            return null;
        }
        public string DoubleToString(
            double value,      // number 
            int digits = 8    // number of digits after decimal point 
        )
        {
            return null;
        }
        public string EnumToString(
            /*any_enum */int value      // any type enumeration value 
        )
        {
            return null;
        }
        public string IntegerToString(
            long number,              // number 
            int str_len = 0,           // length of result string 
            ushort fill_symbol = ' '      // filler 
        )
        {
            return null;
        }
        public string ShortToString(
            ushort symbol_code      // symbol 
        )
        {
            return null;
        }
        public string ShortArrayToString(
            ushort[] array,      // array 
            int start = 0,      // starting position in the array 
            int count = -1      // number of symbols 
        )
        {
            return null;
        }
        public string TimeToString(
            datetime value,                           // number 
            int mode = TIME_DATE | TIME_MINUTES      // output format 
        )
        {
            return null;
        }
        public double NormalizeDouble(
                double value,      // normalized number 
                int digits      // number of digits after decimal point 
            )
        {
            return 0.0;
        }
        public int StringToCharArray(
            string text_string,         // source string 
            char[]/*&*/  array,             // array 
            int start = 0,             // starting position in the array 
            int count = -1,            // number of symbols 
            int codepage = CP_ACP      // code page 
        )
        {
            return 0;
        }
        public int StringToColor(
            string color_string      // string representation of color 
        )
        {
            return 0;
        }
        public double StringToDouble(
            string value      // string 
        )
        {
            return 0.0;
        }
        public long StringToInteger(
            string value      // string 
        )
        {
            return 0;
        }
        public int StringToShortArray(
            string text_string,     // source string 
            ushort[]/*&*/ array,         // array 
            int start = 0,         // starting position in the array 
            int count = -1         // number of symbols 
        )
        {
            return 0;
        }
        public datetime StringToTime(
            string value      // date string 
        )
        {
            return default(datetime);
        }
        public string StringFormat(
                string format,     // string with format description 
                params object[] args              // parameters 
                )
        {
            return null;
        }
        public string CharToStr(
            char char_code     // ASCII-code 
        )
        {
            return null;
        }
        public string DoubleToStr(
            double value,     // value 
            int digits     // precision 
        )
        {
            return null;
        }
        public double StrToDouble(
            string value      // value 
        )
        {
            return 0.0;
        }
        public int StrToInteger(
            string value      // string 
        )
        {
            return 0;
        }
        public datetime StrToTime(
            string value      // string 
        )
        {
            return default(datetime);
        }
        public string TimeToStr(
            datetime value,                           // value 
            int mode = TIME_DATE | TIME_MINUTES      // format 
        )
        {
            return null;
        }
        //Math Functions
        public double MathAbs(
            double value      // numeric value 
        )
        {
            return 0.0;
        }
        public double MathArccos(
            double val     // -1<val<1 
        )
        {
            return 0.0;
        }
        public double MathArcsin(
            double val      // -1<value<1 
        )
        {
            return 0.0;
        }
        public double MathArctan(
            double value      // tangent 
        )
        {
            return 0.0;
        }
        public double MathCeil(
            double val      // number 
        )
        {
            return 0.0;
        }
        public double MathCos(
            double value      // number 
        )
        {
            return 0.0;
        }
        public double MathExp(
            double value      // power for the number e 
        )
        {
            return 0.0;
        }
        public double MathFloor(
            double val     // number 
        )
        {
            return 0.0;
        }
        public double MathLog(
            double val      // value to take the logarithm 
        )
        {
            return 0.0;
        }
        public double MathLog10(
            double val      // number to take logarithm 
        )
        {
            return 0.0;
        }
        public double MathMax(
            double value1,     // first value 
            double value2      // second value 
        )
        {
            return 0.0;
        }
        public double MathMin(
            double value1,     // first value 
            double value2      // second value 
        )
        {
            return 0.0;
        }
        public double MathMod(
            double value,      // dividend value 
            double value2      // divisor value 
        )
        {
            return 0.0;
        }
        public double MathPow(
            double  _base,         // base  
            double exponent      // exponent value 
        )
        {
            return 0.0;
        }
        public int MathRand()
        {
            return 0;
        }
        public double MathRound(
            double value      // value to be rounded 
        )
        {
            return 0.0;
        }
        public double MathSin(
            double value      // argument in radians 
        )
        {
            return 0.0;
        }
        public double MathSqrt(
            double value      // positive number 
        )
        {
            return 0.0;
        }
        public void MathSrand(
            int seed      // initializing number 
        )
        {

        }
        public double MathTan(
            double rad      // argument in radians 
        )
        {
            return 0.0;
        }
        public bool MathIsValidNumber(
            double number      // number to check 
        )
        {
            return false;
        }
        public bool StringAdd(
            ref string string_var,        // string, to which we add 
            string add_substring      // string, which is added 
        )
        {
            return false;
        }
        public int StringBufferLen(
            string string_var      // string 
        )
        {
            return 0;
        }
        public int StringCompare(
            ref string string1,                 // the first string in the comparison 
            ref string string2,                 // the second string in the comparison 
            bool case_sensitive = true      // case sensitivity mode selection for the comparison 
        )
        {
            return 0;
        }
        public string StringConcatenate(
            string argument1,        // first parameter of any simple type 
            string argument2,        // second parameter of any simple type 
            params object[] args                    // next parameter of any simple type 
        )
        {
            return null;
        }
        public bool StringFill(
            ref string string_var,       // string to fill 
            ushort character         // symbol that will fill the string 
        )
        {
            return false;
        }
        public int StringFind(
            string string_value,        // string in which search is made 
            string match_substring,     // what is searched 
            int start_pos = 0          // from what position search starts 
        )
        {
            return 0;
        }
        public ushort StringGetCharacter(
            string string_value,     // string 
            int pos               // symbol position in the string 
        )
        {
            return 0;
        }
        public bool StringInit(
            ref string string_var,       // string to initialize 
            int new_len = 0,        // required string length after initialization 
            ushort character = 0       // symbol, by which the string will be filled 
        )
        {
            return false;
        }
        public int StringLen(
            string string_value      // string 
        )
        {
            return 0;
        }
        public int StringReplace(
            ref string str,              // the string in which substrings will be replaced 

            string find,             // the searched substring 

            string replacement       // the substring that will be inserted to the found positions 
        )
        {
            return 0;
        }
        public bool StringSetCharacter(
            ref string string_var,       // string 
            int pos,              // position 
            ushort character         // character 
        )
        {
            return false;
        }
        public int StringSplit(
            string string_value,       // A string to search in 
            ushort separator,          // A separator using which substrings will be searched 
            string[]/*&*/    result         // An array passed by reference to get the found substrings 
        )
        {
            return 0;
        }

        public string StringSubstr(
            string string_value,     // string 
            int start_pos,        // position to start with 
            int length = 0          // length of extracted string 
        )
        {
            return null;
        }

        public bool StringToLower(
            ref string string_var      // string to process 
        )
        {
            return false;
        }
        public bool StringToUpper(
            ref string string_var      // string to process 
        )
        {
            return false;
        }
        public string StringTrimLeft(

     string text      // string to cut 
)
        {
            return null;
        }
        public string StringTrimRight(

     string text      // string to cut 
)
        {
            return null;
        }
        public ushort StringGetChar(
            string string_value,     // string 
            int pos               // position 
        )
        {
            return 0;
        }
        public string StringSetChar(
            string string_var,       // string 
            int pos,              // position 
            ushort value             // char code 
        )
        {
            return null;
        }
        public datetime TimeCurrent()
        {
            return default(datetime);
        }
        public datetime TimeLocal()
        {
            return default(datetime);
        }
        public datetime TimeGMT()
        {
            return default(datetime);
        }
        public int TimeDaylightSavings()
        {
            return 0;
        }
        public int TimeGMTOffset()
        {
            return 0;
        }
        public void TimeToStruct(
            datetime dt,            // date and time 
           ref MqlDateTime dt_struct      // structure for the adoption of values 
)
        {
           
        }
        public datetime StructToTime(
            ref MqlDateTime dt_struct      // structure of the date and time 
)
        {
            return default(datetime);
        }
        public int Seconds()
        {
            return 0;
        }
        public int Minute()
        {
            return 0;
        }
        public int Hour()
        {
            return 0;
        }
        public int Day()
        {
            return 0;
        }
        public int DayOfWeek()
        {
            return 0;
        }
        public int DayOfYear()
        {
            return 0;
        }
        public int Month()
        {
            return 0;
        }
        public int Year()
        {
            return 0;
        }
        public int TimeDay(
            datetime date            // date and time 
        )
        {
            return 0;
        }
        public int TimeDayOfWeek(
            datetime date            // date and time 
        )
        {
            return 0;
        }
        public int TimeDayOfYear(
            datetime date            // date and time 
        )
        {
            return 0;
        }
        public int TimeHour(
            datetime date            // date and time 
        )
        {
            return 0;
        }
        public int TimeMinute(
            datetime date            // date and time 
        )
        {
            return 0;
        }
        public int TimeMonth(
            datetime date            // date and time 
        )
        {
            return 0;
        }
        public int TimeSeconds(
            datetime date            // date and time 
        )
        {
            return 0;
        }
        public int TimeYear(
            datetime date            // date and time 
        )
        {
            return 0;
        }

        //Account Functions

        public double AccountInfoDouble(
            int property_id      // identifier of the property 
        )
        {
            return 0.0;
        }
        public long AccountInfoInteger(
            int property_id      // Identifier of the property 
        )
        {
            return 0;
        }
        public string AccountInfoString(
            int property_id      // Identifier of the property 
        )
        {
            return null;
        }
        public double AccountBalance()
        {
            return 0.0;
        }
        public double AccountCredit()
        {
            return 0.0;
        }
        public string AccountCompany()
        {
            return null;
        }
        public string AccountCurrency()
        {
            return null;
        }
        public double AccountEquity()
        {
            return 0.0;
        }
        public double AccountFreeMargin()
        {
            return 0.0;
        }
        public double AccountFreeMarginCheck(
            string symbol,     // symbol 
            int cmd,        // trade operation 
            double volume      // volume 
        )
        {
            return 0.0;
        }
        public double AccountFreeMarginMode()
        {
            return 0.0;
        }
        public int AccountLeverage()
        {
            return 0;
        }
        public double AccountMargin()
        {
            return 0.0;
        }
        public string AccountName()
        {
            return null;
        }
        public int AccountNumber()
        {
            return 0;
        }
        public double AccountProfit()
        {
            return 0.0;
        }
        public string AccountServer()
        {
            return null;
        }
        public int AccountStopoutLevel()
        {
            return 0;
        }
        public int AccountStopoutMode()
        {
            return 0;
        }

        //Checkup Functions
        public int GetLastError()
        {
            return 0;
        }
        public bool IsStopped()
        {
            return false;
        }
        public int UninitializeReason()
        {
            return 0;
        }
        public int MQLInfoInteger(
            int property_id      // identifier of a property 
        )
        {
            return 0;
        }
        public string MQLInfoString(
            int property_id      // Identifier of a property 
        )
        {
            return null;
        }
        public void MQLSetInteger(
            int property_id,         // identifier of a property 
            int property_value       // value to be set 
        )
        {
        }
        public int TerminalInfoInteger(
            int property_id      // identifier of a property 
        )
        {
            return 0;
        }
        public double TerminalInfoDouble(
            int property_id      // identifier of a property 
        )
        {
            return 0.0;
        }
        public string TerminalInfoString(
            int property_id      // identifier of a property 
        )
        {
            return null;
        }
        public string Symbol()
        {
            return null;
        }
        public int Period()
        {
            return 0;
        }
        public int Digits()
        {
            return 0;
        }
        public double Point()
        {
            return 0.0;
        }
        public bool IsConnected()
        {
            return false;
        }
        public bool IsDemo()
        {
            return false;
        }
        public bool IsDllsAllowed()
        {
            return false;
        }
        public bool IsExpertEnabled()
        {
            return false;
        }
        public bool IsLibrariesAllowed()
        {
            return false;
        }
        public bool IsOptimization()
        {
            return false;
        }
        public bool IsTesting()
        {
            return false;
        }
        public bool IsTradeAllowed()
        {
            return false;
        }
        public bool IsTradeContextBusy()
        {
            return false;
        }
        public bool IsVisualMode()
        {
            return false;
        }
        public string TerminalCompany()
        {
            return null;
        }
        public string TerminalName()
        {
            return null;
        }
        public string TerminalPath()
        {
            return null;
        }

        //Market Info Functions:
        public double MarketInfo(
            string symbol,     // symbol 
            ENUM_MARKET_INFO_MODE type        // information type 
        )
        {
            return 0.0;
        }
        public int SymbolsTotal(
            bool selected      // True - only symbols in MarketWatch 
        )
        {
            return 0;
        }
        public string SymbolName(
            int pos,          // number in the list 
            bool selected      // true - only symbols in MarketWatch 
        )
        {
            return null;
        }
        public bool SymbolSelect(
            string name,       // symbol name 
            bool select      // add or remove 
        )
        {
            return false;
        }

        public double SymbolInfoDouble(
            string name,       // symbol 
            ENUM_SYMBOL_INFO_DOUBLE prop_id     // identifier of the property 
        )
        {
            return 0.0;
        }
        public long SymbolInfoInteger(
            string name,      // symbol 
            ENUM_SYMBOL_INFO_INTEGER prop_id    // identifier of a property 

        )
        {
            return 0;
        }
        public bool SymbolInfoInteger(
            string name,      // symbol 
            ENUM_SYMBOL_INFO_INTEGER prop_id,   // identifier of a property 
            ref long long_var   // here we accept the property value 
)
        {
            return false;
        }
        public string SymbolInfoString(
            string name,        // Symbol 
            ENUM_SYMBOL_INFO_STRING prop_id      // Property identifier 
        )
        {
            return null;
        }

        public bool SymbolInfoString(
            string name,        // Symbol 
            ENUM_SYMBOL_INFO_STRING prop_id,     // Property identifier 
            ref string string_var   // Here we accept the property value 
)
        {
            return false;
        }

        public bool SymbolInfoTick(
            string symbol,     // symbol name 
            ref MqlTick tick        // reference to a structure 
)
        {
            return false;
        }

        public bool SymbolInfoSessionQuote(
            string name,                // symbol name 
            ENUM_DAY_OF_WEEK day_of_week,         // day of the week 
            uint session_index,       // session index 
            ref datetime from,                // time of the session beginning 
            ref datetime to                   // time of the session end 
)
        {
            return false;
        }

        public bool SymbolInfoSessionTrade(
            string name,                // symbol name 
            ENUM_DAY_OF_WEEK day_of_week,         // day of the week 
            uint session_index,       // session index 
            ref datetime from,                // session beginning time 
            ref datetime to                   // session end time 
)
        {
            return false;
        }

        //Time series and indicator access functions:
        public long SeriesInfoInteger(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe,       // period 
            ENUM_SERIES_INFO_INTEGER prop_id          // property identifier 
        )
        {
            return 0;
        }
        public bool SeriesInfoInteger(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe,       // period 
            ENUM_SERIES_INFO_INTEGER prop_id,         // property ID 
            ref long long_var         // variable for getting info 
)
        {
            return false;
        }
        public bool RefreshRates()
        {
            return false;
        }
        public int CopyRates(
            string symbol_name,       // symbol name 
            ENUM_TIMEFRAMES timeframe,         // period 
            int start_pos,         // start position 
            int count,             // data count to copy 
            MqlRates[] rates_array      // target array to copy 
)
        {
            return 0;
        }
        public int CopyRates(
            string symbol_name,       // symbol name 
            ENUM_TIMEFRAMES timeframe,         // period 
            datetime start_time,        // start date and time 
            int count,             // data count to copy 
            MqlRates[] rates_array      // target array to copy 
)
        {
            return 0;
        }
        public int CopyRates(
            string symbol_name,       // symbol name 
            ENUM_TIMEFRAMES timeframe,         // period 
            datetime start_time,        // start date and time 
            datetime stop_time,         // end date and time 
            MqlRates[] rates_array      // target array to copy 
)
        {
            return 0;
        }
        public int CopyTime(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe,       // period 
            int start_pos,       // start position 
            int count,           // data count to copy 
            datetime[] time_array     // target array to copy open times 
)
        {
            return 0;
        }
        public int CopyTime(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe,       // period 
            datetime start_time,      // start date and time 
            int count,           // data count to copy 
            datetime[] time_array     // target array to copy  open times 
)
        {
            return 0;
        }
        public int CopyTime(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe,       // period 
            datetime start_time,      // start date and time 
            datetime stop_time,       // stop date and time 
            datetime[] time_array     // target array to copy open times 
)
        {
            return 0;
        }
        public int CopyOpen(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe,       // period 
            int start_pos,       // start position 
            int count,           // data count to copy 
            double[] open_array     // target array to copy open prices 
)
        {
            return 0;
        }
        public int CopyOpen(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe,       // period 
            datetime start_time,      // start date and time 
            int count,           // data count to copy 
            double[] open_array     // target array for bar open prices 
)
        {
            return 0;
        }
        public int CopyOpen(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe,       // period 
            datetime start_time,      // start date and time 
            datetime stop_time,       // stop date and time 
            double[] open_array     // target array for bar open values 
)
        {
            return 0;
        }
        public int CopyHigh(
            string symbol_name,      // symbol name 
            ENUM_TIMEFRAMES timeframe,        // period 
            int start_pos,        // start position 
            int count,            // data count to copy 
            double[] high_array      // target array to copy 
)
        {
            return 0;
        }

        public int CopyHigh(
            string symbol_name,      // symbol name 
            ENUM_TIMEFRAMES timeframe,        // period 
            datetime start_time,       // start date and time 
            int count,            // data count to copy 
            double[] high_array      // target array to copy 
)
        {
            return 0;
        }
        public int CopyHigh(
            string symbol_name,      // symbol name 
            ENUM_TIMEFRAMES timeframe,        // period 
            datetime start_time,       // start date and time 
            datetime stop_time,        // stop date and time 
            double[] high_array      // target array to copy 
)
        {
            return 0;
        }
        public int CopyLow(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe,       // period 
            int start_pos,       // start position 
            int count,           // data count to copy 
            double[] low_array      // target array to copy 
)
        {
            return 0;
        }
        public int CopyLow(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe,       // period 
            datetime start_time,      // start date and time 
            int count,           // data count to copy 
            double[] low_array      // target array to copy 
)
        {
            return 0;
        }
        public int CopyLow(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe,       // period 
            datetime start_time,      // start date and time 
            datetime stop_time,       // stop date and time 
            double[] low_array      // target array to copy 
)
        {
            return 0;
        }
        public int CopyClose(
            string symbol_name,       // symbol name 
            ENUM_TIMEFRAMES timeframe,         // period 
            int start_pos,         // start position 
            int count,             // data count to copy 
            double[] close_array      // target array to copy 
)
        {
            return 0;
        }
        public int CopyClose(
            string symbol_name,       // symbol name 
            ENUM_TIMEFRAMES timeframe,         // period 
            datetime start_time,        // start date and time 
            int count,             // data count to copy 
            double[] close_array      // target array to copy 
)
        {
            return 0;
        }
        public int CopyClose(
            string symbol_name,       // symbol name 
            ENUM_TIMEFRAMES timeframe,         // period 
            datetime start_time,        // start date and time 
            datetime stop_time,         // stop date and time 
            double[] close_array      // target array to copy 
)
        {
            return 0;
        }
        public int CopyTickVolume(
            string symbol_name,      // symbol name 
            ENUM_TIMEFRAMES timeframe,        // period 
            int start_pos,        // start position 
            int count,            // data count to copy 
            long[] volume_array    // target array for tick volumes 
)        {
            return 0;
        }
        public int CopyTickVolume(
            string symbol_name,      // symbol name 
            ENUM_TIMEFRAMES timeframe,        // period 
            datetime start_time,       // start date and time 
            int count,            // data count to copy 
            long[] volume_array    // target array for tick volumes 
)
        {
            return 0;
        }
        public int CopyTickVolume(
            string symbol_name,      // symbol name 
            ENUM_TIMEFRAMES timeframe,        // period 
            datetime start_time,       // start date and time 
            datetime stop_time,        // stop date and time 
            long[] volume_array    // target array for tick volumes 
)
        {
            return 0;
        }
        public int Bars(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe        // period 
        )
        {
            return 0;
        }
        public int Bars(
            string symbol_name,     // symbol name 
            ENUM_TIMEFRAMES timeframe,       // period 
            datetime start_time,      // start date and time 
            datetime stop_time        // end date and time 
        )
        {
            return 0;
        }
        public int iBars(
            string symbol,          // symbol 
            ENUM_TIMEFRAMES timeframe        // timeframe 
        )
        {
            return 0;
        }
        public int iBarShift(
            string symbol,          // symbol 
            ENUM_TIMEFRAMES timeframe,       // timeframe 
            datetime time,            // time 
            bool exact = false      // mode 
        )
        {
            return 0;
        }
        public double iClose(
            string symbol,          // symbol 
            ENUM_TIMEFRAMES timeframe,       // timeframe 
            int shift            // shift 
        )
        {
            return 0.0;
        }
        public double iHigh(
            string symbol,          // symbol 
            ENUM_TIMEFRAMES timeframe,       // timeframe 
            int shift            // shift 
        )
        {
            return 0.0;
        }
        public int iHighest(
            string symbol,          // symbol 
            ENUM_TIMEFRAMES timeframe,       // timeframe 
            int type,            // timeseries 
            int count,           // cont 
            int start            // start 
        )
        {
            return 0;
        }
        public double iLow(
            string symbol,          // symbol 
            ENUM_TIMEFRAMES timeframe,       // timeframe 
            int shift            // shift 
        )
        {
            return 0;
        }
        public int iLowest(
            string symbol,          // symbol 
            ENUM_TIMEFRAMES timeframe,       // timeframe 
            int type,            // timeseries id 
            int count,           // count 
            int start            // starting index 
        )
        {
            return 0;
        }
        public double iOpen(
            string symbol,          // symbol 
            int timeframe,       // timeframe 
            int shift            // shift 
        )
        {
            return 0.0;
        }
        public datetime iTime(
            string symbol,          // symbol 
            ENUM_TIMEFRAMES timeframe,       // timeframe 
            int shift            // shift 
        )
        {
            return default(datetime);
        }
        public long iVolume(
            string symbol,          // symbol 
            ENUM_TIMEFRAMES timeframe,       // timeframe 
            int shift            // shift 
        )
        {
            return 0;
        }

        //Chart Operations
        public bool ChartApplyTemplate(
                long chart_id,     // Chart ID 

            string filename      // Template file name 
        )
        {
            return false;
        }
        public bool ChartSaveTemplate(
                    long chart_id,     // Chart ID 

            string filename      // Filename to save the template 
        )
        {
            return false;
        }
        public int ChartWindowFind(
            long chart_id,                  // chart identifier 
            string indicator_shortname        // short indicator name, see INDICATOR_SHORTNAME 
        )
        {
            return 0;
        }
        public int ChartWindowFind()
        {
            return 0;
        }
        public bool ChartTimePriceToXY(
            long chart_id,     // Chart ID 
            int sub_window,   // The number of the subwindow 
            datetime time,         // Time on the chart 
            double price,        // Price on the chart 
            ref int x,            // The X coordinate for the time on the chart 
            ref int y             // The Y coordinates for the price on the chart 
)
        {
            return false;
        }
        public bool ChartXYToTimePrice(
            long chart_id,     // Chart ID 
            int x,            // The X coordinate on the chart 
            int y,            // The Y coordinate on the chart 
            ref int sub_window,   // The number of the subwindow 
            ref datetime time,         // Time on the chart 
            ref double price         // Price on the chart 
)
        {
            return false;
        }
        public long ChartOpen(
            string symbol,     // Symbol name 
            ENUM_TIMEFRAMES period      // Period 
        )
        {
            return 0;
        }
        public long ChartFirst()
        {
            return 0;
        }
        public long ChartNext(
            long chart_id      // Chart ID 
        )
        {
            return 0;
        }
        public bool ChartClose(
            long chart_id = 0      // Chart ID 
        )
        {
            return false;
        }
        public string ChartSymbol(
            long chart_id = 0      // Chart ID 
        )
        {
            return null;
        }
        public ENUM_TIMEFRAMES ChartPeriod(
            long chart_id = 0      // Chart ID 
        )
        {
            return ENUM_TIMEFRAMES.PERIOD_CURRENT;
        }
        public void ChartRedraw(
            long chart_id = 0      // Chart ID 
        )
        {

        }
        public bool ChartSetDouble(
            long chart_id,     // Chart ID 
            int prop_id,      // Property ID 
            double value         // Value 
        )
        {
            return false;
        }
        public bool ChartSetInteger(
            long chart_id,     // Chart ID 
            int prop_id,      // Property ID 
            long value         // Value 
        )
        {
            return false;
        }
        public bool ChartSetInteger(
            long chart_id,     // Chart ID 
            int property_id,  // Property ID 
            uint sub_window,   // Chart subwindow 
            long value         // Value 
        )
        {
            return false;
        }
        public bool ChartSetString(
            long chart_id,      // Chart ID 
            int prop_id,       // Property ID 
            string str_value      // Value 
        )
        {
            return false;
        }
        public double ChartGetDouble(
            long chart_id,          // Chart ID 
            int prop_id,           // Property ID 
            int sub_window = 0       // subwindow number, if necessary 
        )
        {
            return 0.0;
        }
        public bool ChartGetDouble(
            long chart_id,        // Chart ID 
            int prop_id,         // Property ID 
            int sub_window,      // Subwindow number 
            ref double double_var       // Target variable for the chart property 
)
        {
            return false;
        }
        public long ChartGetInteger(
            long chart_id,          // Chart ID 
            int prop_id,           // Property ID 
            int sub_window = 0       // subwindow number, if necessary 
        )
        {
            return 0;
        }
        public bool ChartGetInteger(
            long chart_id,        // Chart ID 
            int prop_id,         // Property ID 
            int sub_window,      // subwindow number 
            ref long long_var         // Target variable for the property 
)
        {
            return false;
        }
        public string ChartGetString(
            long chart_id,          // Chart ID 
            int prop_id            // Property ID 
        )
        {
            return null;
        }
        public bool ChartGetString(
            long chart_id,        // Chart ID 
            int prop_id,         // Property ID 
            ref string string_var       // Target variable for the property 
)
        {
            return false;
        }
        public bool ChartNavigate(
            long chart_id,     // Chart ID 
            int position,     // Position 
            int shift = 0       // Shift value 
        )
        {
            return false;
        }
        public long ChartID()
        {
            return 0;
        }
        public bool ChartIndicatorDelete(
            long chart_id,              // chart id 
            int sub_window,            // number of the subwindow 

    string indicator_shortname    // short name of the indicator 
)
        {
            return false;
        }
        public string ChartIndicatorName(
            long chart_id,      // chart id 
            int sub_window,    // number of the subwindow 
            int index          // index of the indicator in the list of indicators added to the chart subwindow 
        )
        {
            return null;
        }
        public int ChartIndicatorsTotal(
            long chart_id,      // chart id 
            int sub_window     // number of the subwindow 
        )
        {
            return 0;
        }
        public int ChartWindowOnDropped()
        {
            return 0;
        }
        public double ChartPriceOnDropped()
        {
            return 0.0;
        }
        public datetime ChartTimeOnDropped()
        {
            return default(datetime);
        }
        public int ChartXOnDropped()
        {
            return 0;
        }
        public int ChartYOnDropped()
        {
            return 0;
        }
        public bool ChartSetSymbolPeriod(
            long chart_id,     // Chart ID 
            string symbol,       // Symbol name 
            ENUM_TIMEFRAMES period        // Period 
        )
        {
            return false;
        }

        public bool ChartScreenShot(
            long chart_id,                   // Chart ID 
            string filename,                   // Symbol name 
            int width,                      // Width 
            int height,                     // Height 
            ENUM_ALIGN_MODE align_mode = ENUM_ALIGN_MODE.ALIGN_RIGHT      // Alignment type 
        )
        {
            return false;
        }
        public int WindowBarsPerChart()
        {
            return 0;
        }
        public string WindowExpertName()
        {
            return null;
        }
        public int WindowFind(
            string name   // name 
        )
        {
            return 0;
        }
        public int WindowFirstVisibleBar()
        {
            return 0;
        }
        public int WindowHandle(
            string symbol,     // symbol 
            int timeframe   // timeframe 
        )
        {
            return 0;
        }
        public int WindowIsVisible(
            int index     // subwindow 
        )
        {
            return 0;
        }
        public int WindowOnDropped()
        {
            return 0;
        }
        public int WindowPriceMax(
            int index = 0   // subwindow 
        )
        {
            return 0;
        }
        public int WindowPriceMin(
            int index = 0   // subwindow 
        )
        {
            return 0;
        }
        public double WindowPriceOnDropped()
        {
            return 0.0;
        }
        public void WindowRedraw()
        {

        }

        public bool WindowScreenShot(
            string filename,                   // file name 
            int size_x,                     // width 
            int size_y,                     // height 
            int start_bar = -1,               // first visible bar 
            int chart_scale = -1,             // scale 
            int chart_mode = -1               // mode 
        )
        {
            return false;
        }
        public datetime WindowTimeOnDropped()
        {
            return default(datetime);
        }
        public int WindowsTotal()
        {
            return 0;
        }
        public int WindowXOnDropped()
        {
            return 0;
        }
        public int WindowYOnDropped()
        {
            return 0;
        }

        //Order Functions:
        public bool OrderClose(
            int ticket,      // ticket 
            double lots,        // volume 
            double price,       // close price 
            int slippage,    // slippage 
            int arrow_color  // color 
        )
        {
            return false;
        }
        public bool OrderCloseBy(
            int ticket,      // ticket to close 
            int opposite,    // opposite ticket 
            int arrow_color  // color 
        )
        {
            return false;
        }
        public double OrderClosePrice()
        {
            return 0.0;
        }
        public datetime OrderCloseTime()
        {
            return default(datetime);
        }
        public string OrderComment()
        {
            return null;
        }
        public double OrderCommission()
        {
            return 0.0;
        }
        public bool OrderDelete(
            int ticket,      // ticket 
            int arrow_color  // color 
        )
        {
            return false;
        }
        public datetime OrderExpiration()
        {
            return default(datetime);
        }
        public double OrderLots()
        {
            return 0.0;
        }
        public int OrderMagicNumber()
        {
            return 0;
        }
        public bool OrderModify(
            int ticket,      // ticket 
            double price,       // price 
            double stoploss,    // stop loss 
            double takeprofit,  // take profit 
            datetime expiration,  // expiration 
            int arrow_color  // color 
        )
        {
            return false;
        }
        public double OrderOpenPrice()
        {
            return 0.0;
        }
        public datetime OrderOpenTime()
        {
            return default(datetime);
        }
        public void OrderPrint()
        {
        }
        public double OrderProfit()
        {
            return 0.0;
        }

        //select
        //
        //[in]  Selecting flags.It can be any of the following values :
        //
        //SELECT_BY_POS - index in the order pool,
        //SELECT_BY_TICKET - index is order ticket.
        //
        //pool = MODE_TRADES
        //
        //[in]  Optional order pool index.Used when the selected parameter is SELECT_BY_POS.It can be any of the following values :
        //
        //MODE_TRADES(default) - order selected from trading pool(opened and pending orders),
        //MODE_HISTORY - order selected from history pool(closed and canceled order).
        //
        public const int MODE_TRADES = 0;
        public const int MODE_HISTORY = 1;
        public const int SELECT_BY_POS = 0;
        public const int SELECT_BY_TICKET = 1;

        public const int clrNONE = -1;

        //OP_BUY - buy order,
        //OP_SELL - sell order,
        //OP_BUYLIMIT - buy limit pending order,
        //OP_BUYSTOP - buy stop pending order,
        //OP_SELLLIMIT - sell limit pending order,
        //OP_SELLSTOP - sell stop pending order.
        public const int OP_BUY = 0;
        public const int OP_SELL = 1;
        public const int OP_BUYLIMIT = 2;
        public const int OP_BUYSTOP = 3;
        public const int OP_SELLLIMIT = 4;
        public const int OP_SELLSTOP = 5;

        public bool OrderSelect(
            int index,            // index or order ticket 
            int select,           // flag 
            int pool = MODE_TRADES  // mode 
        )
        {
            return false;
        }
        public int OrderSend(
            string symbol,              // symbol 
            int cmd,                 // operation 
            double volume,              // volume 
            double price,               // price 
            int slippage,            // slippage 
            double stoploss,            // stop loss 
            double takeprofit,          // take profit 
            string comment = null,        // comment 
            int magic = 0,             // magic number 
            datetime expiration = default(datetime),        // pending order expiration 
            int arrow_color = clrNONE  // color 
        )
        {
            return 0;
        }
        public int OrdersHistoryTotal()
        {
            return 0;
        }
        public double OrderStopLoss()
        {
            return 0.0;
        }
        public int OrdersTotal()
        {
            return 0;
        }
        public double OrderSwap()
        {
            return 0.0;
        }
        public string OrderSymbol()
        {
            return null;
        }
        public double OrderTakeProfit()
        {
            return 0.0;
        }
        public int OrderTicket()
        {
            return 0;
        }
        public int OrderType()
        {
            return 0;
        }


        //Trade Signals:
        public double SignalBaseGetDouble(
            ENUM_SIGNAL_BASE_DOUBLE property_id     // property identifier 
        )
        {
            return 0.0;
        }
        public long SignalBaseGetInteger(
            ENUM_SIGNAL_BASE_INTEGER property_id     // property identifier 
        )
        {
            return 0;
        }
        public string SignalBaseGetString(
            ENUM_SIGNAL_BASE_STRING property_id     // property identifier 
        )
        {
            return null;
        }
        public bool SignalBaseSelect(
            int index     // signal index 
        )
        {
            return false;
        }
        public int SignalBaseTotal()
        {
            return 0;
        }

        public double SignalInfoGetDouble(
            ENUM_SIGNAL_INFO_DOUBLE property_id     // property identifier 
        )
        {
            return 0.0;
        }
        public long SignalInfoGetInteger(
            ENUM_SIGNAL_INFO_INTEGER property_id     // property identifier 
        )
        {
            return 0;
        }
        public string SignalInfoGetString(
            ENUM_SIGNAL_INFO_STRING property_id     // property identifier 
        )
        {
            return null;
        }
        public bool SignalInfoSetDouble(
            ENUM_SIGNAL_INFO_DOUBLE property_id,     // property identifier 
            double value            // new value 
        )
        {
            return false;
        }
        public bool SignalInfoSetInteger(
            ENUM_SIGNAL_INFO_INTEGER property_id,     // property identifier 
            long value            // new value 
        )
        {
            return false;
        }
        public bool SignalSubscribe(
            long signal_id     // signal id  
        )
        {
            return false;
        }
        public bool SignalUnsubscribe()
        {
            return false;
        }

        //Global Variables
        public bool GlobalVariableCheck(
            string name      // Global variable name 
        )
        {
            return false;
        }
        public datetime GlobalVariableTime(
            string name      // name 
        )
        {
            return default(datetime);
        }
        public bool GlobalVariableDel(
            string name      // Global variable name 
        )
        {
            return false;
        }
        public double GlobalVariableGet(
            string name      // Global variable name 
        )
        {
            return 0.0;
        }
        public bool GlobalVariableGet(
            string name,              // Global variable name 
            ref double double_var         // This variable will contain the value of the global variable 
        )
        {
            return false;
        }
        public string GlobalVariableName(
            int index      // Global variable number in the list of global variables 
        )
        {
            return null;
        }
        public datetime GlobalVariableSet(
            string name,      // Global variable name 
            double value      // Value to set 
        )
        {
            return default(datetime);
        }

        public void GlobalVariablesFlush()
        {

        }
        public bool GlobalVariableTemp(
            string name      // Global variable name 
        )
        {
            return false;
        }
        public bool GlobalVariableSetOnCondition(
            string name,            // Global variable name 
            double value,           // New value for variable if condition is true 
            double check_value      // Check value condition 
        )
        {
            return false;
        }
        public int GlobalVariablesDeleteAll(
            string prefix_name = null,     // All global variables with names beginning with the prefix 
            datetime limit_data = default(datetime)          // All global variables that were changed before this date 
        )
        {
            return 0;
        }
        public int GlobalVariablesTotal()
        {
            return 0;
        }

        //File Functions:
        public long FileFindFirst(
            string file_filter,          // String - search filter 
            ref string        returned_filename,    // Name of the file or subdirectory found 
	        int common_flag = 0         // Defines the search 
        )
        {
            return 0;
        }
        public bool FileFindNext(
            long search_handle,         // Search handle 
            ref string   returned_filename      // Name of the file or subdirectory found 
        )
        {
            return false;
        }
        public void FileFindClose(
            long search_handle      //  Search handle 
        )
        {
        }
        public bool FileIsExist(

            string file_name,       // File name 

            int common_flag = 0    // Search area 
        )
        {
            return false;
        }
        public int FileOpen(
            string file_name,           // File name 
            int open_flags,          // Combination of flags 
            char delimiter = ';',       // Delimiter 
            int codepage = CP_ACP      // Code page 
        )
        {
            return 0;
        }
        public void FileClose(
            int file_handle      // File handle 
        )
        {

        }
        public bool FileCopy(
            string src_file_name,     // Name of a source file 
            int common_flag,       // Location 
            string dst_file_name,     // Name of the destination file 
            int mode_flags         // Access mode 
        )
        {
            return false;
        }
        public bool FileDelete(
            string file_name,     // File name to delete  
            int common_flag = 0  // Location of the file to delete 
        )
        {
            return false;
        }
        bool FileMove(
            string src_file_name,    // File name for the move operation 
            int common_flag,      // Location 
            string dst_file_name,    // Name of the destination file 
            int mode_flags        // Access mode 
        )
        {
            return false;
        }
        public void FileFlush(
            int file_handle      // File handle 
        )
        {
            
        }
        public long FileGetInteger(
            int file_handle,   // File handle 
            ENUM_FILE_PROPERTY_INTEGER property_id    // Property ID 
        )
        {
            return 0;
        }
        public long FileGetInteger(
            string file_name,            // File name 
            ENUM_FILE_PROPERTY_INTEGER  property_id,          // Property ID 
	        bool common_folder = false   // The file is viewed in a local folder (false) 
        )
        {
            return 0;
        }

        public bool FileIsEnding(
            int file_handle      // File handle 
        )
        {
            return false;
        }
        public bool FileIsLineEnding(
            int file_handle      // File handle 
        )
        {
            return false;
        }
        public uint FileReadArray(
            int file_handle,               // File handle 
            object[]/*&*/  array/*[]*/,                   // Array to record 
            int start = 0,                   // start array position to write 
            int count = WHOLE_ARRAY          // count to read 
        )
        {
            return 0;
        }
        public bool FileReadBool(
            int file_handle    // File handle 
        )
        {
            return false;
        }
        public datetime FileReadDatetime(
            int file_handle    // File handle 
        )
        {
            return default(datetime);
        }
        public double FileReadDouble(
            int file_handle,       // File handle 
            int size = DOUBLE_VALUE  // Size 
        )
        {
            return 0.0;
        }
        public float FileReadFloat(
            int file_handle    // File handle 
        )
        {
            return 0.0f;
        }
        public int FileReadInteger(
            int file_handle,        // File handle 
            int size = INT_VALUE      // Size of an integer in bytes 
        )
        {
            return 0;
        }
        public long FileReadLong(
            int file_handle    // File handle 
        )
        {
            return 0;
        }
        public double FileReadNumber(
            int file_handle    // File handle 
        )
        {
            return 0.0;
        }
        public string FileReadString(
            int file_handle,     // File handle 
            int length = 0         // Length of the string 
        )
        {
            return null;
        }
        public uint FileReadStruct(
            int file_handle,        // file handle 
            ref object/*&*/  struct_object,      // target structure to which the contents are read 
            int size = -1             // structure size in bytes 
        )
        {
            return 0;
        }
        public enum ENUM_FILE_POSITION
        {
            SEEK_SET_,//File beginning
            SEEK_CUR_,//Current position of a file pointer
            SEEK_END_,//File end
        }
        public bool FileSeek(
            int file_handle,     // File handle 
            long offset,          // In bytes 
            ENUM_FILE_POSITION origin           // Position for reference 
        )
        {
            return false;
        }
        public ulong FileSize(
            int file_handle    // File handle 
        )
        {
            return 0;
        }
        public ulong FileTell(
            int file_handle    // File handle 
        )
        {
            return 0;
        }
        public uint FileWrite(
            int file_handle,   // File handle 
            params object[] args
            // List of recorded parameters 
            )
        {
            return 0;
        }
        public uint FileWriteArray(
            int file_handle,         // File handle 
            object[]/*&*/  array/*[]*/,             // Array 
            int start = 0,             // Start index in the array 
            int count = WHOLE_ARRAY    // Number of elements 
        )
        {
            return 0;
        }
        public uint FileWriteDouble(
            int file_handle,     // File handle 
            double value            // Value to write 
        )
        {
            return 0;
        }
        public uint FileWriteFloat(
            int file_handle,     // File handle 
            float value            // Value to be written 
        )
        {
            return 0;
        }
        public uint FileWriteInteger(
            int file_handle,        // File handle 
            int value,              // Value to be written 
            int size = INT_VALUE      // Size in bytes 
        )
        {
            return 0;
        }

        public uint FileWriteLong(
            int file_handle,     // File handle 
            long value            // Value to be written 
        )
        {
            return 0;
        }
        public uint FileWriteString(
            int file_handle,    // File handle 

            string text_string,    // string to write 

            int length = 0       // number of symbols 
        )
        {
            return 0;
        }
        public uint FileWriteStruct(
            int file_handle,       // File handle 

            object/*&*/  struct_object,     // link to an object 

            int size = -1            // size to be written in bytes 
        )
        {
            return 0;
        }
        public bool FolderCreate(
            string folder_name,       // String with the name of the new folder 
            int common_flag = 0      // Scope 
        )
        {
            return false;
        }
        public bool FolderDelete(
            string folder_name,       // String with the name of the folder to delete 
            int common_flag = 0      // Scope 
        )
        {
            return false;
        }
        public bool FolderClean(
            string folder_name,       // String with the name of the deleted folder 
            int common_flag = 0      // Scope 
        )
        {
            return false;
        }
        public int FileOpenHistory(
            int filename,       // file name 
            int mode,           // open mode 
            int delimiter = ';'   // delimiter 
        )
        {
            return 0;
        }
        //Custom Indicators Functions:
        public void HideTestIndicators(
            bool hide     // flag 
        )
        {
        }
        public bool IndicatorSetDouble(
            int prop_id,           // identifier 
            double prop_value         // value to be set 
        )
        {
            return false;
        }
        public bool IndicatorSetDouble(
            int prop_id,           // identifier 
            int prop_modifier,     // modifier 
            double prop_value         // value to be set 
        )
        {
            return false;
        }
        public bool IndicatorSetInteger(
            int prop_id,           // identifier 
            int prop_value         // value to be set 
        )
        {
            return false;
        }
        public bool IndicatorSetInteger(
            int prop_id,           // identifier 
            int prop_modifier,     // modifier 
            int prop_value         // value to be set 
        )
        {
            return false;
        }
        public bool IndicatorSetString(
            int prop_id,           // identifier 
            string prop_value         // value to be set 
        )
        {
            return false;
        }
        public bool IndicatorSetString(
            int prop_id,           // identifier 
            int prop_modifier,     // modifier 
            string prop_value         // value to be set 
        )
        {
            return false;
        }


        public bool SetIndexBuffer(
            int index,         // buffer index 
            double[] buffer,      // array 
            ENUM_INDEXBUFFER_TYPE data_type      // what will be stored 
        )
        {
            return false;
        }
        public bool SetIndexBuffer(
            int index,         // buffer index 
            double[] buffer       // array 
        )
        {
            return false;
        }
        public bool IndicatorBuffers(
            int count         // buffers 
        )
        {
            return false;
        }
        public int IndicatorCounted()
        {
            return 0;
        }
        public void IndicatorDigits(
            int digits         // digits 
        )
        {
        }
        public void IndicatorShortName(
            string name         // name 
        )
        {

        }
        public void SetIndexArrow(
            int index,       // line index 
            int code         // code 
        )
        {
        }
        public void SetIndexDrawBegin(
            int index,       // line index 
            int begin        // position 
        )
        {

        }
        public void SetIndexEmptyValue(
            int index,       // line index 
            double value        // new "empty value" 
        )
        {

        }
        public void SetIndexLabel(
            int index,       // line index 
            string text         // text 
        )
        {

        }
        public void SetIndexShift(
            int index,       // line index 
            int shift        // shift 
        )
        {
        }
        public void SetIndexStyle(
            int index,       // line index 
            int type,        // line type 
            int style = EMPTY, // line style 
            int width = EMPTY, // line width 
            int clr = clrNONE  // line color 
        )
        {

        }
        public void SetLevelStyle(
            int draw_style,       // drawing style 
            int line_width,       // line width 
            int clr               // color 
        )
        {

        }
        public void SetLevelValue(
            int level,       // level 
            double value        // value 
        )
        {

        }

        public bool ObjectCreate(
            long chart_id,      // chart ID 
            string object_name,   // object name 
            ENUM_OBJECT object_type,   // object type 
            int sub_window,    // window index 
            datetime time1,         // time of the first anchor point 
            double price1,        // price of the first anchor point 
            params object[] args
	        //datetime      timeN = 0,       // time of the N-th anchor point 
	        //double        priceN = 0       // price of the N-th anchor point 
        )
        {
            return false;
        }

        public bool ObjectCreate(
            string object_name,   // object name 
            ENUM_OBJECT object_type,   // object type 
            int sub_window,    // window index 
            datetime time1,         // time of the first anchor point 
            double price1,        // price of the first anchor point 
            datetime time2,       // time of the second anchor point 
            double price2,      // price of the second anchor point 
            datetime time3,       // time of the third anchor point 
            double price3       // price of the third anchor point 
        )
        {
            return false;
        }
        public string ObjectName(
            int object_index   // object index 
        )
        {
            return null;
        }
        public bool ObjectDelete(
            long chart_id,     // chart ID 
            string object_name   // object name 
        )
        {
            return false;
        }
        public bool ObjectDelete(
            string object_name   // object name 
        )
        {
            return false;
        }
        public int ObjectsDeleteAll(
            long chart_id,           // chart ID 
            int sub_window = EMPTY,   // window index 
            int object_type = EMPTY   // object type 
        )
        {
            return 0;
        }
        public int ObjectsDeleteAll(
            int sub_window = EMPTY,   // window index 
            int object_type = EMPTY   // object type 
        )
        {
            return 0;
        }
        public int ObjectsDeleteAll(
            long chart_id,   // chart ID 
            string prefix,   // prefix in object name 
            int sub_window = EMPTY,   // window index 
            int object_type = EMPTY   // object type 
        )
        {
            return 0;
        }
        public int ObjectFind(
            long chart_id,     // chart ID 
            string object_name   // object name 
        )
        {
            return 0;
        }
        public int ObjectFind(
            string object_name   // object name 
        )
        {
            return 0;
        }
        public datetime ObjectGetTimeByValue(
            long chart_id,      // chart ID 
            string object_name,   // object name 
            double value,         // price 
            int line_id = 0      // line identifier 
        )
        {
            return default(datetime);
        }
        public double ObjectGetValueByTime(
            long chart_id,      // chart ID 
            string object_name,   // object name 
            datetime time,          // time 
            int line_id = 0      // line ID 
        )
        {
            return 0.0;
        }
        public bool ObjectMove(
            string object_name,   // object name 
            int point_index,   // anchor point number 
            datetime time,          // Time 
            double price          // Price 
        )
        {
            return false;
        }

        public int ObjectsTotal(
            long chart_id,          // chart identifier 
            int sub_window = -1,     // window index 
            int type = -1            // object type 
        )
        {
            return 0;
        }
        public int ObjectsTotal(
            int type = EMPTY        // object type 
        )
        {
            return 0;
        }
        public double ObjectGetDouble(
            long chart_id,         // chart identifier 
            string object_name,      // object name 
            int prop_id,          // property identifier 
            int prop_modifier = 0   // property modifier, if required 
        )
        {
            return 0.0;
        }

        public bool ObjectGetDouble(
            long chart_id,        // chart identifier 
            string object_name,     // object name 
            int prop_id,         // property identifier 
            int prop_modifier,   // property modifier 
            ref double  double_var       // here we accept the property value 
)
        {
            return false;
        }
        public long ObjectGetInteger(
            long chart_id,         // chart identifier 
            string object_name,      // object name 
            int prop_id,          // property identifier 
            int prop_modifier = 0   // property modifier, if required 
        )
        {
            return 0;
        }
        public bool ObjectGetInteger(
            long chart_id,         // chart identifier 
            string object_name,      // object name 
            int prop_id,          // property identifier 
            int prop_modifier,    // property modifier 
            ref long    long_var          // here we accept the property value 
        )
        {
            return false;
        }
        public string ObjectGetString(
            long chart_id,          // chart identifier 
            string object_name,       // object name 
            int prop_id,           // property identifier 
            int prop_modifier = 0    // property modifier, if required 
        )
        {
            return null;
        }

        bool ObjectGetString(
            long chart_id,          // chart identifier 
            string object_name,       // object name 
            int prop_id,           // property identifier 
            int prop_modifier,     // property modifier 
            ref string string_var         // here we accept the property value 
            )
        {
            return false;
        }

        bool ObjectSetDouble(
            long chart_id,        // chart identifier 
            string object_name,     // object name 
            int prop_id,         // property 
            double prop_value       // value 
        )
        {
            return false;
        }
        bool ObjectSetDouble(
            long chart_id,        // chart identifier 
            string object_name,     // object name 
            int prop_id,         // property 
            int prop_modifier,   // modifier 
            double prop_value       // value 
        )
        {
            return false;
        }
        bool ObjectSetInteger(
            long chart_id,       // chart identifier 
            string object_name,    // object name 
            int prop_id,        // property 
            long prop_value      // value 
        )
        {
            return false;
        }
        bool ObjectSetInteger(
            long chart_id,        // chart identifier 
            string object_name,     // object name 
            int prop_id,         // property 
            int prop_modifier,   // modifier 
            long prop_value       // value 
        )
        {
            return false;
        }
        bool ObjectSetString(
            long chart_id,        // chart identifier 
            string object_name,     // object name 
            int prop_id,         // property 
            string prop_value       // value 
        )
        {
            return false;
        }
        bool ObjectSetString(
            long chart_id,        // chart identifier 
            string object_name,     // object name 
            int prop_id,         // property 
            int prop_modifier,   // modifier 
            string prop_value       // value 
        )
        {
            return false;
        }
        bool TextSetFont(
            string name,            // font name or path to font file on the disk 
            int size,            // font size 
            uint flags = 0,         // combination of flags 
            int orientation = 0    // text slope angle 
        )
        {
            return false;
        }
        public bool TextOut(
            string text,          // displayed text 
            int x,             // X coordinate  
            int y,             // Y coordinate  
            uint anchor,        // anchor type 
            uint[]/*&*/           data,       // output buffer 
            uint width,         // buffer width in pixels 
            uint height,        // buffer height in pixels 
            uint color,         // text color 
            ENUM_COLOR_FORMAT   color_format   // color format for output 
        )
        {
            return false;
        }
        public bool TextGetSize(
            string text,    // text string 

            ref uint          width,   // buffer width in pixels 
	        ref uint          height   // buffer height in pixels 
        )
        {
            return false;
        }
        public string ObjectDescription(
            string object_name   // object name 
        )
        {
            return null;
        }
        public double ObjectGet(
            string object_name,   // object name 
            int index          // object property 
        )
        {
            return 0.0;
        }
        public string ObjectGetFiboDescription(
            string object_name,   // object name 
            int index          // level index 
        )
        {
            return null;
        }
        public int ObjectGetShiftByValue(
            string object_name,   // object name 
            double value          // price 
        )
        {
            return 0;
        }
        public double ObjectGetValueByShift(
            string object_name,   // object name 
            int shift          // bar index 
        )
        {
            return 0.0;
        }
        public bool ObjectSet(
            string object_name,   // object name 
            int index,         // property index 
            double value          // value 
        )
        {
            return false;
        }
        public bool ObjectSetFiboDescription(
            string object_name,   // object name 
            int index,         // level index 
            string text           // new description 
        )
        {
            return false;
        }
        public bool ObjectSetText(
            string object_name,         // object name 
            string text,                // description 
            int font_size = 0,         // font size 
            string font_name = null,      // font name 
            int text_color = clrNONE   // text color 
        )
        {
            return false;
        }
        public int ObjectType(
            string object_name   // object name 
        )
        {
            return 0;
        }

        //Indicators
        public double iAC(
            string symbol,     // symbol 
            int timeframe,  // timeframe 
            int shift       // shift 
        )
        {
            return 0.0;
        }
        public double iAD(
            string symbol,     // symbol 
            int timeframe,  // timeframe 
            int shift       // shift 
        )
        {
            return 0.0;
        }
        public double iADX(
            string symbol,        // symbol 
            int timeframe,     // timeframe 
            int period,        // averaging period 
            int applied_price, // applied price 
            int mode,          // line index 
            int shift          // shift 
        )
        {
            return 0.0;
        }
        public double iAlligator(
            string symbol,            // symbol 
            int timeframe,         // timeframe 
            int jaw_period,        // Jaw line averaging period 
            int jaw_shift,         // Jaw line shift 
            int teeth_period,      // Teeth line averaging period 
            int teeth_shift,       // Teeth line shift 
            int lips_period,       // Lips line averaging period 
            int lips_shift,        // Lips line shift 
            int ma_method,         // averaging method 
            int applied_price,     // applied price 
            int mode,              // line index 
            int shift              // shift 
        )
        {
            return 0.0;
        }
        public double iAO(
            string symbol,     // symbol 
            int timeframe,  // timeframe 
            int shift       // shift 
        )
        {
            return 0.0;
        }
        public double iATR(
            string symbol,     // symbol 
            int timeframe,  // timeframe 
            int period,     // averaging period 
            int shift       // shift 
        )
        {
            return 0.0;
        }
        public double iBearsPower(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int period,           // averaging period 
            int applied_price,    // applied price 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iBands(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int period,           // averaging period 
            double deviation,        // standard deviations 
            int bands_shift,      // bands shift 
            int applied_price,    // applied price 
            int mode,             // line index 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iBandsOnArray(
            double[] array,          // array with data 
            int total,            // number of elements 
            int period,           // averaging period 
            double deviation,        // deviation 
            int bands_shift,      // bands shift 
            int mode,             // line index 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iBullsPower(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int period,           // averaging period 
            int applied_price,    // applied price 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iCCI(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int period,           // averaging period 
            int applied_price,    // applied price 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iCCIOnArray(
            double[] array,          // array with data 
            int total,            // number of elements 
            int period,           // averaging period 
            int shift             // shift 
        )
        {
            return 0.0;
        }

        public double iCustom(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            string name,             // path/name of the custom indicator compiled program 
	        params object[] args                            // custom indicator input parameters (if necessary) 
	        //int          mode,             // line index 
	        //int          shift             // shift 
        )
        {
            return 0.0;
        }
        public double iDeMarker(
            string symbol,     // symbol 
            int timeframe,  // timeframe 
            int period,     // averaging period 
            int shift       // shift 
        )
        {
            return 0.0;
        }
        public double iEnvelopes(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int ma_period,        // MA averaging period 
            int ma_method,        // MA averaging method 
            int ma_shift,         // moving average shift 
            int applied_price,    // applied price 
            double deviation,        // deviation (in percents) 
            int mode,             // line index 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iEnvelopesOnArray(
            double[] array,          // array with data 
            int total,            // number of elemements 
            int ma_period,        // MA averaging period 
            int ma_method,        // MA averaging method 
            int ma_shift,         // MA shift 
            double deviation,        // deviation (in percents) 
            int mode,             // line index 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iForce(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int period,           // averaging period 
            int ma_method,        // averaging method 
            int applied_price,    // applied price 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iFractals(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int mode,             // line index 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iGator(
            string symbol,            // symbol 
            int timeframe,         // timeframe 
            int jaw_period,        // Jaw line period 
            int jaw_shift,         // Jaw line shift 
            int teeth_period,      // Teeth line period 
            int teeth_shift,       // Teeth line shift 
            int lips_period,       // Lips line period 
            int lips_shift,        // Lips line shift 
            int ma_method,         // MA averaging method 
            int applied_price,     // applied price 
            int mode,              // line index 
            int shift              // shift 
        )
        {
            return 0.0;
        }
        public double iIchimoku(
            string symbol,            // symbol 
            int timeframe,         // timeframe 
            int tenkan_sen,        // period of Tenkan-sen line 
            int kijun_sen,         // period of Kijun-sen line 
            int senkou_span_b,     // period of Senkou Span B line 
            int mode,              // line index 
            int shift              // shift 
        )
        {
            return 0.0;
        }
        public double iBWMFI(
            string symbol,     // symbol 
            int timeframe,  // timeframe 
            int shift       // shift 
        )
        {
            return 0.0;
        }
        public double iMomentum(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int period,           // averaging period 
            int applied_price,    // applied price 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iMomentumOnArray(
            double[] array,          // array with data 
            int total,            // number of elements 
            int period,           // averaging period 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iMFI(
            string symbol,     // symbol 
            int timeframe,  // timeframe 
            int period,     // averaging period 
            int shift       // shift 
        )
        {
            return 0.0;
        }
        public double iMA(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int ma_period,        // MA averaging period 
            int ma_shift,         // MA shift 
            int ma_method,        // averaging method 
            int applied_price,    // applied price 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iMAOnArray(
            double[] array,          // array with data 
            int total,            // number of elements 
            int ma_period,        // MA averaging period 
            int ma_shift,         // MA shift 
            int ma_method,        // MA averaging method 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iOsMA(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int fast_ema_period,  // Fast EMA period 
            int slow_ema_period,  // Slow EMA period 
            int signal_period,    // Signal line period 
            int applied_price,    // applied price 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iMACD(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int fast_ema_period,  // Fast EMA period 
            int slow_ema_period,  // Slow EMA period 
            int signal_period,    // Signal line period 
            int applied_price,    // applied price 
            int mode,             // line index 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iOBV(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int applied_price,    // applied price 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iSAR(
            string symbol,            // symbol 
            int timeframe,         // timeframe 
            double step,              // price increment step - acceleration factor 
            double maximum,           // maximum value of step 
            int shift              // shift 
        )
        {
            return 0.0;
        }
        public double iRSI(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int period,           // period 
            int applied_price,    // applied price 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iRSIOnArray(
            double[] array,          // array with data 
            int total,            // number of elements 
            int period,           // averaging period 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iRVI(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int period,           // averaging period 
            int mode,             // line index 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iStdDev(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int ma_period,        // MA averaging period 
            int ma_shift,         // MA shift 
            int ma_method,        // MA averaging method 
            int applied_price,    // applied price 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iStdDevOnArray(
            double[] array,          // array with data 
            int total,            // number of elements 
            int ma_period,        // MA averaging period 
            int ma_shift,         // MA shift 
            int ma_method,        // MA averaging method 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iStochastic(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int Kperiod,          // K line period 
            int Dperiod,          // D line period 
            int slowing,          // slowing 
            int method,           // averaging method 
            int price_field,      // price (Low/High or Close/Close) 
            int mode,             // line index 
            int shift             // shift 
        )
        {
            return 0.0;
        }
        public double iWPR(
            string symbol,           // symbol 
            int timeframe,        // timeframe 
            int period,           // period 
            int shift             // shift 
        )
        {
            return 0.0;
        }
    }
}
