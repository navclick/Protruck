using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProTrukRepo.Util
{
    public static class Constant
    {
        public static readonly string ApplicationCookieName = "GoLogistics";

        public static readonly string ConnectionConfigDefault = "DefaultConnection";
        public static readonly string ConnectionConfigServer = "ConnServer";
        public static readonly string ConnectionConfigDatabase = "ConnDatabase";
        public static readonly string ConnectionConfigUser = "ConnUser";
        public static readonly string ConnectionConfigPassword = "ConnPassword";

        public static readonly string ConfigKeyDBLocal = @"GoLogisticsEntitiesLocal";
        public static readonly string ConfigKeyDBProd = @"GoLogisticsEntitiesProd";

        public static readonly Random Rand = new Random();
        public static readonly int MaxErrFlags = 3;

        // ********************************************** REGULAR EXPRESSIONS ********************************************** //

        //public static readonly Regex CellNumberRegex = new Regex(@"^(03\d{9})$", RegexOptions.Compiled); //^(\s*03[0-9]\d{8}\s*)*$
        //public static readonly Regex CellNumberRegexWebServiceAlternate = new Regex(@"^((\+923|923|00923|3|03)\d{9})$", RegexOptions.Compiled);
        //public static readonly Regex CellNumberRegexMessageParsing = new Regex(@"(^|\s+)((03|923|\+923|00923)\d{2}[\p{P}|\p{S}|\s+]*\d{3}[\p{P}|\p{S}|\s+]*\d{4})(\s+|$)", RegexOptions.Compiled);
        public static readonly Regex CellNumberRegexOrders = new Regex(@"^((\+923)|(923)|(803)|(903)|(00923)|(03))-{0,1}\d{2}-{0,1}(\d{3}-{0,1}\d{4}|\d{4}-{0,1}\d{3})$", RegexOptions.Compiled);
        public static readonly Regex CellNumbersDigitsOnly = new Regex(@"[^\d]", RegexOptions.Compiled);
        // (^|\s+)((03|\+923|00923)\d{2}(.)?\d{3}(.)?\d{4})(\s+|$) <-- accepts numbers longer than 11 because of the .

        public static readonly Regex RegexDeviceIMEI = new Regex(@"^(\d{15})$", RegexOptions.Compiled);
        public static readonly Regex RegexEmailSubject = new Regex(@"(\r|\n)", RegexOptions.Compiled);


        // ********************************************** PATHS ********************************************** //

        public static readonly string PathWebLogs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"logs\GoLogisticsWeb.log");        //C:\HostingSpaces\gologist\gorickshaw.pk\wwwroot
        public static readonly string PathWebAPILogs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"logs\GoLogisticsWebAPI.log");  //C:\HostingSpaces\gologist\gorickshaw.pk\wwwroot
        public static readonly string PathRecordings = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"media\");                      //C:\HostingSpaces\gologist\gorickshaw.pk\wwwroot
        public static readonly string PathRecordingsDir = @"D:\Google Drive\SIPRecordings\";
        public static readonly string PathRecordingsFileName = "Master*";
        public static readonly string PathRecordingsSearchedList = @"D:\\Google Drive\SIPRecordings\FilesSearchedlist.txt";
        public static readonly string PathUserImage = "/content/images/avatar/";
        public static readonly string PathUserDefultImage = "/content/images/avatar/noimage.png";

        // *************************************** STORED PROCEDURES ***************************************** //

        public static readonly string SP_GetDeviceID = @"[dbo].SP_GetDeviceID @p0, @p1, @p2, @p3";


        // *************************************** USERS ROLES | IDs \ ACC STATUS ***************************************** //

        public static readonly int DeveloperUserMaxID = 100;
        public static readonly string UserRoleAdmin = "Admin";
        public static readonly string UserRoleCustomer = "Customer";
        public static readonly string UserRoleCSR = "CSR";
        public static readonly string UserRoleOperations = "Operations";
        public static readonly string UserRoleHOD = "HOD";
        public static readonly string UserRoleSales = "Sales";


        //****************************Response Messages******************************
        public static readonly string MSGRecordFound = "Record found";
        public static readonly string MDGNoRecordFound= "No record found!";
        public static readonly string MDGNoLoginFailed = "Login Failed!";

        //*****************************

        public enum AccountStatus
        {
            Disabled = 0,
            Enabled = 1
        }

       

       



        // ********************************************** DRIVERs ********************************************** //

        //public static readonly Regex RegexDeveloperIDs = new Regex(ConfigurationManager.AppSettings["DeveloperIDsRegex"], RegexOptions.Compiled);
        public static readonly int DriverDevicesMaxID = 1000;
        public static readonly int DriverDevicesMinID = 62;
        public static readonly int DriverDeveloperMaxID = 50;
        public static readonly string NoDrivers = "No Drivers Found";
        public static readonly int MaxCommentLength = 50;


        public static readonly double GpsDefaultLat = 24.746149;
        public static readonly double GpsDefaultLong = 66.985411;
        public static readonly double GpsLatMin = -90;
        public static readonly double GpsLatMax = 90;
        public static readonly double GpsLonMin = -180;
        public static readonly double GpsLonMax = 180;
        public static readonly double GpsRadiusMax = 3500;             // rick search radius in meters 3500
        public static readonly double GpsRadiusMaxOverrideSched = 3500;  // rick search radius in meters
        public static readonly double GpsRadiusMaxOverrideIqra = 1000;  // rick search radius in meters
        public static readonly double GpsRadiusIncrement = 3500;    // rick search radius increment in meters
        public static readonly int GpsRadiusMaxIterations = 1;      // num iterations of increasing radius
        public static readonly int GpsRadiusMinRick = 3;            // min rick for current radius
        public static readonly string DistFromCurrLoc = "0";        // to be handled in app
        public static readonly double FareFromCurrLoc = 0;          // to be handled in app

        public static readonly int GpsRadiusPickup = 1000;          // rick search radius in meters

        public static readonly double RickPartnerShare = 20;
        public static readonly double RickHiredShare = 0;

        public static readonly string RickHiredDailySalary = "Daily Hired Driver Salary";
        public static readonly double RickHiredDailyPayout = 1000;




        // ********************************************** ORDERs ********************************************** //



        public static readonly int MaxAddressLength = 145;
        public static readonly int MaxFeedbackLength = 495;


        public static readonly TimeSpan OrderSchedGenerateFor = new TimeSpan(2, 0, 0);
        public static readonly TimeSpan Request60MinsPrior = new TimeSpan(0, 60, 0);


        public enum ErrorCodes
        {
            None = 0,
            Success = 1,
            UnspecifiedError = 100,
            ErrorIncorrectParameters = 101,
            ErrorOrderCancelled = 102
        }

        public enum EasyPay_Status
        {
            INITIATED = 0,
            PENDING = 1,
            FAILED = 2,
            PAID = 3
        }

        public enum EasyPay_PaymentMethod
        {
            OTC,
            CC,
            MA
        }

        public enum EasyPay_PaymentTypes
        {
            Wallet = 1,
            Invoice = 2
        }

        public enum ServiceRequestStatuses
        {
            ConsumerRequested = 0,                      // Open State
            DriverAccepted = 1,                         // Open State
            DriverCancelled = 2,                        // Terminal State
            ConsumerCancelled = 3,                      // Terminal State
            ConsumerOrderHandled = 4                    // Terminal State
        }

        public enum ServiceOrderStatuses
        {
            // Billable
            ConsumerRequested = 0,                                                  // NewOrder         
            CallDone = 10,                                                          // Called
            DriverAccepted = 100,                                                   // DrAcc
            DriverCancelled = 200,                                                  // DrCan
            ConsumerCancelled = 300,                    // Order Terminal State     // CuCanC                   // Y
            ConsumerCancelledNoCharge = 301,            // Order Terminal State     // CuCanNC
            DriverEnrouteToCust = 400,                                              // DrToPick
            DriverAtOrigin = 500,                                                   // DrAtPick
            ConsumerNotifiedDriverAtOrigin = 600,                                   // CuInfPick
            ConsumerEnroute = 700,                                                  // CuMtrSta
            ConsumerAtDestination = 800,                                            // CuMtrSto

            FailureGeneralService = 900,                // SEMI Terminal State      // Error
            FailureConsumerNotification = 901,          // SEMI Terminal State      // ErrInf
            ConsumerAtDestinationPaymentIssue = 902,    // SEMI Terminal State      // CuErrPay
            ConsumerCancelRequest = 903,                // SEMI Terminal State      // CuCanReq
            DriverCompleteRequest = 904,                // SEMI Terminal State      // DrComReq
            ConsumerScheduled = 999,                    // SEMI Terminal State      // CuSched

            OrderCompleteSuccess = 1000,                // Order Terminal State     // Complete                 // Y
            FailureResolvedGeneral = 1100,              // Order Terminal State     // CuErrRes

            InquiryWithAddress = 2000,                  // Order Terminal State     // CuInq
            AppTest = 2001,                             // Order Terminal State     // CanATest
            CancDuplicate = 2002,                       // Order Terminal State     // CanDup
            OutOfCity = 2003,                           // Order Terminal State     // CanCity
            UrgentRequest = 2004,                       // Order Terminal State     // CanUrg
            CustLeft = 2005,                            // Order Terminal State     // CanLeft
            MonthlyRequest = 2006,                      // Order Terminal State     // CanMonth
            AgentLate = 2007,                           // Order Terminal State     // CanLate
            Holiday = 2008,                             // Order Terminal State     // CanHoliday

            ScheOrderCanc = 2009,                       // Order Terminal State     // CanScheOrder
            OutOfServiceHrs = 2010,                     // Order Terminal State     // CanOutOfServiceHrs
            NonServiceArea = 2011,                      // Order Terminal State     // CanNonServiceArea

            CustNotAnswering = 2100,                    // Order Terminal State     // CanCuAns
            DrNotAvailable = 3000                       // Order Terminal State     // CanDrAv
        }

        public enum RickshawStatuses
        {
            Normal = 0,
            Panic = 100,
            Disabled = 200
        }

        public enum TicketOrderType
        {
            Random = 0,
            Fixed = 1,
            OnRoad = 2
        }

        public enum TicketType
        {
            Cash = 0,
            Credit = 1
        }

        public enum RideType
        {
            OneWay = 0,
            RoundTrip = 1
        }

        public enum PaymentType
        {
            Unpaid = 0,
            Paid = 1,
            PartialPaid = 2,
            BadDebt = 3
        }

        public enum DiscType
        {
            None = 0,
            FlatRs,
            FlatKm,
            PercRs,
            PercKm
        }

        public enum VehicleType
        {
            Rickshaw = 0
        }

        public enum CDRDirection
        {
            Recieved = 1,
            Dialled = 2
        }

        public enum ProcessEventType
        {
            SendBroadcast = 1,
            PostAccTrans = 2
        }


        // ********************************************** Mobile Wallet ********************************************** //
        public enum TransactionSource
        {
            Cash = 1,
            Credit = 2,
            Allowance = 3,
            Payment = 4,
            Reversal = 5,
            EasyPaisa = 6
        }

        public static readonly string OrderCompleteReference = "Order Completion";

        // ********************************************** WEB ********************************************** //

        public static readonly string WebPagesBasicOrders = "BasicOrders";
        public static readonly string WebPagesOpsBasicOrders = "CSRdispatch";
        public static readonly string WebPagesHome = "Index";

        public static readonly string SessionUserID = "uID";
        public static readonly string SessionUserFullName = "uFullName";
        public static readonly string SessionUserPhoneNumber = "uPhoneNumber";
        public static readonly string SessionUserAccountStatus = "uAccountStatus";



        // ********************************************** JOBS ********************************************** //

        public static readonly string ConfigKeyServersSRV1 = @"ServerSRV1";
        public static readonly string ConfigKeyServersLeapSwitch = @"ServerLeapSwitch";
        public static readonly string JobsServersSRV1; //ConfigurationManager.AppSettings[ConfigKeyServersSRV1];
        public static readonly string JobsServersLeapSwitch;// = ConfigurationManager.AppSettings[ConfigKeyServersLeapSwitch];

        public static readonly string JobsQueueDefault = @"default";
        public static readonly string JobsQueueMediumPriority = @"mediumpriority";
        public static readonly string JobsQueueLowPriority = @"lowpriority";

        // http://www.thegeekstuff.com/2009/06/15-practical-crontab-examples/

        //public static readonly string JobsHFSched20Mins = @"*/20 1-21 * * *";       // every x mins, 6am to 2 am Pak Time -> 1am to 21 UTC
        public static readonly string JobsHFSched20Mins = @"*/20 * * * *";          // every x mins
        //public static readonly string JobsHFSched60Mins = @"*/60 1-18 * * *";     // every x mins, 6am to midnight Pak Time -> 1am to 17 UTC
        public static readonly string JobsHFSched1Min = @"* * * * *";               // every x mins        
        public static readonly string JobsHFSched5Min = @"*/5 * * * *";             // every 5 mins
        public static readonly string JobsHFSched6AM = @"0 01 * * *";               // every day at 6 am PST -> 1 am UTC        
        public static readonly string JobsHFSched1AM = @"0 20 * * *";               // every day at 1 am PST -> 20pm UTC        
        public static readonly string JobsHFSched1Hour = @"0 */1 * * *";            // every day at 9 am, 9 pm PST

        public static readonly string JobsHFProcessQueue = @"BGW - HF Process Queue";
        public static readonly string JobsHFGenerateTickets = @"BGW - HF Sched Tickets";
        public static readonly string JobsHFUpdateCDR = @"BGW - HF Update CDR";
        public static readonly string JobsHFBackupDB = @"BGW - HF BackupDB";
        public static readonly string JobsHFUpdETrack = @"BGW - HF ETrack";

        public static readonly string JobsHFSendPush = @"BGW - HF Send Push Notif";
        public static readonly string JobsHFSendSms = @"BGW - HF Send SMS";
        public static readonly string JobsHFSendHisaabSMS = @"BGW - HF Send Hisaab SMS";
        public static readonly string JobsHFPostHiredDrSal = @"BGW - HF Hired Driver Salary";



        // ********************************************** TRACKING ********************************************** //

        public static readonly string TrackingGetCell = @"{cell}";
        public static readonly string TrackingGetTelcoID = @"{telcoID}";
        public static readonly string TrackingGetName = @"{name}";
        public static readonly string TrackingUrl = @"http://outreach.pk/api/sendsms.php/location/track?id=rchgologistictrack&pass=trackrick123&mobile=" + TrackingGetCell;//+ "&telco=" + TrackingGetTelcoID + "&name=" + TrackingGetName;
        public static readonly string TrackingMembersList = @"http://outreach.pk/api/sendsms.php/location/listMembers?id=rchgologistictrack&pass=trackrick123";
        public static readonly string TrackingUsageUrl = @"http://outreach.pk/api/sendsms.php/balance/tracking?id=rchgologistictrack&pass=trackrick123";
        public static readonly string TrackingAddMemberUrl = @"http://outreach.pk/api/sendsms.php/location/addmember?id=rchgologistictrack&pass=trackrick123&mobile=" + TrackingGetCell + "&telco=" + TrackingGetTelcoID + "&name=" + TrackingGetName;
        public static readonly short TrackingTelcoDoNotTrack = -1;
        public static readonly short TrackingTelcoWarid = 0;
        public static readonly short TrackingTelcoZong = 1;
        public static readonly short TrackingTelcoMobilink = 2;
        public static readonly short TrackingTelcoUfone = 3;
        public static readonly short TrackingTelcoTelenor = 4;


        public static readonly int TrackingSchedMinutes = 15;
        public static readonly int TrackingBillingStartingDate = 16;
        public static readonly double TrackingBillingRatePerMinute = 4.25; // ALTERNATE  180,000 / 31 days / 24 hours / 60 minutes
        public static readonly double TrackingTotalCredit = 190000;
        public static readonly double TrackingTotalCreditReserve = 10000;

        public static readonly string TrackingProvGps = "gps";
        public static readonly string TrackingProvNetwork = "network";
        public static readonly string TrackingProvTest = "test";
        public static readonly string TrackingProvETrack = "etrack";


        // ********************************************** EMAIL ********************************************** //

        //public static readonly string[] EmailsDevelopers = new string[] { "faizan.kazi@gologistics.pk", "danish.ahmed@gologistics.pk", "ajay.kumar@gologistics.pk", "irfan.aslam@gologistics.pk" };
        public static readonly string[] EmailsDevelopers = new string[] { "tech@gologistics.pk" };
        public static readonly string[] EmailsOps = new string[] { "khalil.ahmed@gologistics.pk" };
        public static readonly string[] EmailsDevelopersAndOps = new string[] { "tech@gologistics.pk", "ops@gologistics.pk" };

        public static readonly string EmailFrom = @"no-reply@gologistics.pk";
        public static readonly string EmailFromName = @"[Go Logistics]";
        public static readonly string EmailUserName = @"gologistics23K";
        public static readonly string EmailPassword = @"SG.qIhIlpwdlEQ.kGrPSbzbG4Sqqiyi75q8A22cCIxPiCg";
        public static readonly string EmailAPIKey = @"qIhI48MpRXKplTulpwdlEQ";

        public static readonly string EmailTemplateSummaryDaily = "EmailTemplateSummaryDaily.html";



        // ********************************************** SMS ********************************************** //

        public static readonly TimeSpan SMS15MinsPrior = new TimeSpan(0, 15, 0);

        public static readonly string SMSUrl = @"http://www.outreach.pk/api/sendsms.php/sendsms/url";
        public static readonly string SMSPostCell = @"{cell}";
        public static readonly string SMSPostMsg = @"{msg}";
        public static readonly string SMSPostData = @"id=rchgologistictrack&pass=trackrick123&msg=" + SMSPostMsg + "&to=" + SMSPostCell + "&mask=GO Rickshaw&type=json&lang=English";


        // SMS MESSAGES
        public static readonly string SMS0RegistrationUserName = @"{Cell Number}";
        public static readonly string SMS0RegistrationPassword = @"{Password}";
        public static readonly string SMS0Registration =
@"Dear User, Welcome to GO Rickshaw.
Thank you for registering.
Your Cell Number is: " + SMS0RegistrationUserName + @"
Your Password is: " + SMS0RegistrationPassword + @"
GO +92(21)111-00-4646 - Download our app:https://goo.gl/KI2FI7 and enjoy the lowest fares in town!";

        public static readonly string SMS1InquiryID = @"{InquiryID}";
        public static readonly string SMS1Inquiry =
@"Dear User, your inquiry No. IR-" + SMS1InquiryID + @" has been received.
Thank you for getting in touch.
GO +92(21)111-00-4646 - Download our app:https://goo.gl/KI2FI7 and enjoy the lowest fares in town!";

        public static readonly string SMS1BookingSOID = @"{ServiceOrderID}";
        public static readonly string SMS1Booking =
@"Dear User, your booking inquiry No. OR-" + SMS1BookingSOID + @" has been received.
Our representative will contact you shortly for confirmation.
Thank you for using GO +92(21)111-00-4646 - Download our app:https://goo.gl/KI2FI7 and enjoy the lowest fares in town!";

        public static readonly string SMS2CancellationPendingSOID = @"{ServiceOrderID}";
        public static readonly string SMS2CancellationPending =
@"Dear User, your request to cancel booking No.OR-" + SMS2CancellationPendingSOID + @" has been received.
Our representative will contact you shortly for the details.
GO +92(21)111-00-4646 - Download our app:https://goo.gl/KI2FI7 and enjoy the lowest fares in town!";

        public static readonly string SMS2CancellationSOID = @"{ServiceOrderID}";
        public static readonly string SMS2Cancellation =
@"Dear User, your booking No.OR-" + SMS2CancellationSOID + @" has been cancelled.
We regret the inconvenience. GO +92(21)111-00-4646 - Download our app:https://goo.gl/KI2FI7 and enjoy the lowest fares in town!";

        public static readonly string SMS2DrAssSOID = @"{ServiceOrderID}";
        public static readonly string SMS2DrAssPickTime = @"{PickTime}";
        public static readonly string SMS2DrAssEstDist = @"{EstimatedDist}";
        public static readonly string SMS2DrAssEstFare = @"{EstimatedFare}";
        public static readonly string SMS2DrAssigned =
@"Dear User, your booking No.OR-" + SMS2DrAssSOID + @" has been confirmed. Booking Summary:
Pickup Time: " + SMS2DrAssPickTime + @"
Estimated Distance: " + SMS2DrAssEstDist + @" km 
Estimated Fare: Rs. " + SMS2DrAssEstFare + @"/-
Download our app and watch the Rickshaw coming to you live! https://goo.gl/KI2FI7";

        public static readonly string SMS3RideLateSOID = @"{ServiceOrderID}";
        public static readonly string SMS3RideLate =
@"Dear User, your booking No.OR-" + SMS3RideLateSOID + @" is running a little late. 
Please be patient, the Rickshaw will reach you momentarily. 
GO +92(21)111-00-4646";

        public static readonly string SMS5DriverReachedDrName = @"{DriverName}";
        public static readonly string SMS5DriverReachedDrPlate = @"{DriverPlate}";
        public static readonly string SMS5DriverReachedTripCost = @"{TripCost}";
        public static readonly string SMS5DriverReached =
@"Dear User, Mr. " + SMS5DriverReachedDrName + @" with Rickshaw number " + SMS5DriverReachedDrPlate + @"- has reached you.
Trip Charges will be Rs. " + SMS5DriverReachedTripCost + @".
Thank you for using GO +92(21)111-00-4646";

        public static readonly string SMS6OrderCompletion =
@"Dear User, you have arrived at your destination. 
Looking forward to your valuable feedback. 
Thank you for using GO +92(21)111-00-4646";


        public static readonly string HisaabSMSDrName = @"{DriverName}";
        public static readonly string HisaabSMSTotalRides = @"{DriverPlate}";
        public static readonly string HisaabSMSTotalEarning = @"{DriverEarning}";
        public static readonly string HisaabSMSDriverShare = @"{DriverShare}";

        public static readonly string HisaabSMSPartnerDriver =
@"Driver Name: " + HisaabSMSDrName + @" 
Kal ke Orders: " + HisaabSMSTotalRides + @"
Kal ka Share: Rs. " + HisaabSMSDriverShare + @"
Mazeed Maloomaat ke liye Call Center se rabta karen. GO Rickshaw +92(21)-3840519";

        // SMS DRIVER ASSIGNED
        // SMS Unconfirmed Booking
        // SMS Order Issue

        public enum SmsStatusOutreach
        {
            Unsent = 0,
            Successful = 100,
            UnSuccessful = 101,
            ErrInvalidCredentials = 200,
            ErrCustAccExpired = 203,
            ErrInvalidSmsMasking = 204,
            ErrInvalidDestNumber = 206,
            ErrInvalidParameters = 208,
            ErrAccountBlocked = 209,
            ErrInvalidLanguage = 210,
            ErrAccountCreditFinished = 211,
            SuccessMessageSentToTelco = 300
        }


        // ********************************************** PUSH ********************************************** //

        // PUSH - Customer
        public static readonly string CustPushOrderID = @"{OrderID}";
        //Complete
        public static readonly string OrderComplete_FirePostDataTitle = "Your Ride has completed";
        public static readonly string OrderComplete_FirePostDataText = "Dear Customer your ride OR- " + CustPushOrderID + @" is completed. Don't forget to rate it! Thank you for using GO Rickshaw. ";
        public static readonly int OrderComplete_FirePostDataButtons = 2;
        public static readonly string OrderComplete_FirePostActionButton = "OKAY";
        public static readonly string OrderComplete_FirePostCancelButton = "CANCEL";
        public static readonly int OrderComplete_FirePostPopupType = (int)Constant.popupTypes.Success;
        public static readonly string OrderComplete_FirePostNotificationTitle = "Your Ride has completed";
        public static readonly string OrderComplete_FirePostNotificationText = "Dear Customer your ride OR- " + CustPushOrderID + @" is completed. Don't forget to rate it! Thank you for using GO Rickshaw. ";
        public static readonly string OrderComplete_FirePostNotificationIcon = "rick";
        public static readonly string OrderComplete_FirePostNotificationActivity = "MainActivity";
        //Order Rick Assign
        public static readonly string OrdRickAssign_FirePostDataTitle = "A Rickshaw has been assigned to your order";
        public static readonly string OrdRickAssign_FirePostDataText = "Dear Customer, A Rickshaw has been aissgned to your order OR- " + CustPushOrderID + @". Thank you for using GO Rickshaw. ";
        public static readonly int OrdRickAssign_FirePostDataButtons = 2;
        public static readonly string OrdRickAssign_FirePostActionButton = "OKAY";
        public static readonly string OrdRickAssign_FirePostCancelButton = "CANCEL";
        public static readonly int OrdRickAssign_FirePostPopupType = (int)Constant.popupTypes.Info;
        public static readonly string OrdRickAssign_FirePostNotificationTitle = "A Rickshaw has been assigned to your order";
        public static readonly string OrdRickAssign_FirePostNotificationText = "Dear Customer, A Rickshaw has been aissgned to your order OR- " + CustPushOrderID + @". Thank you for using GO Rickshaw. ";
        public static readonly string OrdRickAssign_FirePostNotificationIcon = "rick";
        public static readonly string OrdRickAssign_FirePostNotificationActivity = "MainActivity";
        //Cancel
        public static readonly string OrderCancel_FirePostDataTitle = "Your Ride was Cancelled";
        public static readonly string OrderCancel_FirePostDataText = "Dear Customer, Your ride for order OR- " + CustPushOrderID + @" has been cancelled. We regret the inconvenience. ";
        public static readonly int OrderCancel_FirePostDataButtons = 2;
        public static readonly string OrderCancel_FirePostActionButton = "OKAY";
        public static readonly string OrderCancel_FirePostCancelButton = "CANCEL";
        public static readonly int OrderCancel_FirePostPopupType = (int)Constant.popupTypes.Warning;
        public static readonly string OrderCancel_FirePostNotificationTitle = "Your order has been cancelled.";
        public static readonly string OrderCancel_FirePostNotificationText = "Dear Customer, Your ride for order OR- " + CustPushOrderID + @" has been cancelled. We regret the inconvenience. ";
        public static readonly string OrderCancel_FirePostNotificationIcon = "rick";
        public static readonly string OrderCancel_FirePostNotificationActivity = "MainActivity";

        // PUSH - Driver
        public static readonly string FCM_OrderNew_NotificationTitle = "New Order";
        public static readonly string FCM_OrderNew_NotificationText = "Shuru Karne ke liye Yahan Dabain.";

        public static readonly string FCM_OrderCancel_NotificationTitle = "Order Cancel";
        public static readonly string FCM_OrderCancel_NotificationText = "Order Cancel ho gaya hai"; //???? ????? ?? ??? ??

        public static readonly string FCM_OrderComplete_NotificationTitle = "Order Complete";
        public static readonly string FCM_OrderComplete_NotificationText = "Order Complete ho gaya hai"; //???? ???? ?? ??? ??

        public static readonly string FCM_NewOrder_NotificationIcon = "ic_launcher";
        public static readonly string FCM_NewOrder_NotificationActivity = "MapsActivity";

        public enum PushMessageDataTypes
        {
            None = 0,
            OrderNew = 1,
            OrderCancel = 2,
            OrderComplete = 3,
            OrderRickAssigned = 4,
            PinLockChange = 100,
            Ping = 101,             // TODO Not Implemented
            Update = 102            // TODO Not Implemented
        }


        // ********************************************** Pop Ups ********************************************** //

        public static class ServiceRequestMessages
        {
            public static readonly string ConsumerRequestSuccess = "Ride has been requested.";
            public static readonly string DeviceTokenUpdateSuccess = "Token Updated Successfully.";
            public static readonly string ConsumerRequestCancelled = "Sorry! Ride has been cancelled!";
            public static readonly string ConsumerRequestError = "Oops! Something went wrong! We're fixing it.";
            public static readonly string DevUploadComplete = "Upload Complete.";
            public static readonly string StatusChangeRequestError = "Status already changed.Please refresh page and try again.";
            public static readonly string RebroadcastNoRick = "No Rickshaws were found to rebroadcast this order. Please try again.";
        }


        public static readonly string ConfigKeyAppVersionCodeDriver = "AppVersionCodeDriver";
        public static readonly string AppVersionCodeDriver; //= ConfigurationManager.AppSettings["AppVersionCodeDriver"];

        public static readonly string ConfigKeyAppVersionCodeCustomer = "AppVersionCodeCustomer";
        public static readonly string ConfigKeyAppVersionNameCustomer = "AppVersionNameCustomer";
        public static readonly string ConfigKeyAppVersionCodeCustomerForced = "AppVersionCodeCustomerForced";
        public static readonly string ConfigKeyAppVersionNameCustomerForced = "AppVersionNameCustomerForced";

        public static readonly int VersionUpdateType = (int)PopupActionStatus.ForceUpdate;

       
       

        public enum popupTypes
        {
            Success = 0,
            Info = 1,
            Warning = 2,
            Error = 3
        }

        public enum numPopupButtons
        {
            Single = 1,
            Double = 2
        }

        public enum PopupActionStatus
        {
            ForceUpdate = 10010,
            RecommendedUpdate = 10011
        }



        public enum httpStatus
        {
            Ok = (int) 200,
            NoContent =(int) 204
        }



    }
}
