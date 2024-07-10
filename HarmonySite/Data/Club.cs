using System;
using System.Collections.Generic;
using System.IO;
using Syncfusion.XlsIO;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;

[assembly: InternalsVisibleTo("RustyBoffin.HarmonySite.Test")]
namespace RustyBoffin.HarmonySite.Data
{
    [HSTable("clubs", true)]
    public class Club : HSObject
    {
        public int ImportID => GetValue(() => ImportID);    // ID from imported table	integer	int(11)	-	any number
        public string Name => GetValue(() => Name); // Name	text	varchar(192)	Required	any value
        public string PeakBodyAbbr => GetValue(() => PeakBodyAbbr); // Abbreviation	text	varchar(192)	-	any value
        public string Type => GetValue(() => Type); // Type	single option from hard-coded set of choices	varchar(192)	Required	one of these values
        public Club PeakBody => GetValue(() => PeakBody);   // Parent body	single option from database table	varchar(192)	-	filtered values from clubs table
        public Region Region => GetValue(() => Region); // Region	single option from database table	varchar(192)	-	filtered values from regions table
        public string ExecName => GetValue(() => ExecName); // Name of governing committee	text	varchar(192)	Required	any value
        public string Address => GetValue(() => Address);   // Postal address	multi-line text box	text	-	any value
        public string Area => GetValue(() => Area); // Area of operation	text	varchar(192)	-	any value
        public string State => GetValue(() => State);   // State	single option from hard-coded set of choices	varchar(192)	-	one of these values
        public string Phone => GetValue(() => Phone);   // Phone number(s)	text	varchar(192)	-	any value
        public int ExpiresGrace => GetValue(() => ExpiresGrace);    // Days grace before membership expiry	text	varchar(192)	-	any value
        public string RestrictDues => GetValue(() => RestrictDues); // Dues only accepted	single option from hard-coded set of choices	varchar(192)	-	one of these values
        public bool Privacy => GetValue(() => Privacy); // Members can nominate privacy?	boolean (yes/no)	varchar(3)	-	Yes or No
        public bool Real => GetValue(() => Real);   // Real club/parent body?	boolean (yes/no)	varchar(3)	-	Yes or No
        public bool Performance => GetValue(() => Performance); // Groups are performance-based?	boolean (yes/no)	varchar(3)	-	Yes or No
        public bool Sharing => GetValue(() => Sharing); // Enable file-sharing via Common dir?	boolean (yes/no)	varchar(3)	-	Yes or No
        public bool ShowClubs => GetValue(() => ShowClubs); // Association has a concept of a "club"?	boolean (yes/no)	varchar(3)	-	Yes or No
        public bool PeakMemberships => GetValue(() => PeakMemberships); // Members have club AND peak body memberships	boolean (yes/no)	varchar(3)	-	Yes or No
        public int PeakBodyPart => GetValue(() => PeakBodyPart);    // Name of one constituent group	text	varchar(192)	-	any value
        public int PeakBodyParts => GetValue(() => PeakBodyParts);  // Name of several constituent groups	text	varchar(192)	-	any value
        public int PeakBodyRegion => GetValue(() => PeakBodyRegion);    // Name of one sub-region	text	varchar(192)	-	any value
        public int PeakBodyRegions => GetValue(() => PeakBodyRegions);  // Name of several sub-regions	text	varchar(192)	-	any value
        public int PeakBodyConv => GetValue(() => PeakBodyConv);    // Convention name	text	varchar(192)	-	any value
        public bool ClubInvoicing => GetValue(() => ClubInvoicing); // Club Invoicing enabled?	boolean (yes/no)	varchar(3)	-	Yes or No
        public int ClubRenewal => GetValue(() => ClubRenewal);  // Club renewal fee	integer	int(11)	-	any currency value (in cents/pence/etc)
        public int PeakHSStatus => GetValue(() => PeakHSStatus);    // HarmonySite status	single option from hard-coded set of choices	varchar(192)	Required	one of these values
        public int SetupDeleteRecs => GetValue(() => SetupDeleteRecs);  // Records to delete during setup	multi-line text box	text	-	any value
        public int DuesType => GetValue(() => DuesType);    // Fees payable	single option from database (dropdowns)	varchar(192)	-	one of these values | Administer
        public FeeSchedulePeriod DuesSchedule => GetValue(() => DuesSchedule); // Payment frequency	single option from database table	varchar(192)	-	values from feesperiods table
        public int Amount => GetValue(() => Amount);    // Amount	integer	int(11)	-	any currency value (in cents/pence/etc)
        public string AdminNotes => GetValue(() => AdminNotes); // Admin Notes	WYSIWYG (HTML) multi-line text box	text	-	any value
        public DateTime Registration => GetValue(() => Registration);   // Registration date	date	date	-	any value
        public DateTime LastPaid => GetValue(() => LastPaid);   // Date of last payment	date	date	-	any value
        public DateTime Expires => GetValue(() => Expires); // Expiry date	date	date	-	any value
        public DateTime Resigned => GetValue(() => Resigned);   // Date left	date	date	-	any value
        public DateTime Rejoined => GetValue(() => Rejoined);   // Date re-joined	date	date	-	any value
        public DateTime TimeStamp => GetValue(() => TimeStamp); // Last updated	date	date	-	any value
        public Position PosPresidentPos => GetValue(() => PosPresidentPos); // President	single option from database table	varchar(192)	-	values from positions table
        public Member PosPresidentMem => GetValue(() => PosPresidentMem);   // President member	single option from database table	varchar(192)	-	values from members table
        public string PosPresidentEmail => GetValue(() => PosPresidentEmail);   // President email	email link	varchar(192)	-	any value
        public Position PosSecretaryPos => GetValue(() => PosSecretaryPos); // Secretary	single option from database table	varchar(192)	-	values from positions table
        public Member PosSecretaryMem => GetValue(() => PosSecretaryMem);   // Secretary member	single option from database table	varchar(192)	-	values from members table
        public string PosSecretaryEmail => GetValue(() => PosSecretaryEmail);   // Secretary email	email link	varchar(192)	-	any value
        public Position PosTreasurerPos => GetValue(() => PosTreasurerPos); // Treasurer	single option from database table	varchar(192)	-	values from positions table
        public Member PosTreasurerMem => GetValue(() => PosTreasurerMem);   // Treasurer member	single option from database table	varchar(192)	-	values from members table
        public string PosTreasurerEmail => GetValue(() => PosTreasurerEmail);   // Treasurer email	email link	varchar(192)	-	any value
        public Position PosLiaisonPos => GetValue(() => PosLiaisonPos); // BHA Liaison	single option from database table	varchar(192)	-	values from positions table
        public Member PosLiaisonMem => GetValue(() => PosLiaisonMem);   // BHA Liaison member	single option from database table	varchar(192)	-	values from members table
        public string PosLiaisonEmail => GetValue(() => PosLiaisonEmail);   // BHA Liaison email	email link	varchar(192)	-	any value
        public Position PosClubInvoicingPos => GetValue(() => PosClubInvoicingPos); // Club Invoicing coordinator	single option from database table	varchar(192)	-	values from positions table
        public Member PosClubInvoicingMem => GetValue(() => PosClubInvoicingMem);   // Club Invoicing coordinator member	single option from database table	varchar(192)	-	values from members table
        public string PosClubInvoicingEmail => GetValue(() => PosClubInvoicingEmail);	// Club Invoicing coordinator email	email link	varchar(192)	-	any value


        [HSFilter(nameof(Convention.Club))]
        public HSCollection<Convention> Conventions => GetValues(() => Conventions);
        [HSFilter(nameof(Ensemble.Club))]
        public HSCollection<Ensemble> Ensembles => GetValues(() => Ensembles);
        [HSFilter(nameof(Event.PeakBody))]
        public HSCollection<Event> Events => GetValues(() => Events);
        [HSFilter(nameof(FeeSchedule.Club))]
        public HSCollection<FeeSchedule> FeeSchedules => GetValues(() => FeeSchedules);
        [HSFilter(nameof(Location.Club))]
        public HSCollection<Location> Locations => GetValues(() => Locations);
        [HSFilter(nameof(MemberAward.Club))]
        public HSCollection<MemberAward> Awards => GetValues(() => Awards);
        [HSFilter(nameof(Membership.Club))]
        public HSCollection<Membership> Memberships => GetValues(() => Memberships);
        [HSFilter(nameof(Position.Club))]
        public HSCollection<Position> Positions => GetValues(() => Positions);
        [HSFilter(nameof(Upload.PeakBody))]
        public HSCollection<Upload> Uploads => GetValues(() => Uploads);

        internal Club(HSSession session)
            : base(session)
        {
        }

        internal Club(HSSession session, IWorksheet ws, int row)
            : this(session)
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            id = Convert.ToInt32(ws[row, 1].Number);
            values.Add(nameof(Name), ws[row, 2].Value);
            values.Add(nameof(Type), ws[row, 3].Value);
            values.Add(nameof(ExecName), ws[row, 5].Value);
            values.Add(nameof(Address), ws[row, 6].Value);
            values.Add(nameof(Area), ws[row, 7].Value);
            values.Add(nameof(State), ws[row, 8].Value);
            values.Add(nameof(Phone), ws[row, 9].Value);
            values.Add(nameof(Registration), ws[row, 10].Value);
            values.Add(nameof(LastPaid), ws[row, 11].Value);
            values.Add(nameof(Expires), ws[row, 12].Value);
            values.Add(nameof(Resigned), ws[row, 12].Value);
            values.Add(nameof(stamp), DateTime.Now.ToString());
            Load(values);
        }
        public static void Initialise(HSSession session)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] s = asm.GetManifestResourceNames();

            string site;
            if (session.Connection.Uri.Host.EndsWith(".nz"))
                site = "BHNZ";
            else
                site = "BHA";
            string sheet = string.Format("{0}.clubs.xlsx", site);
            string file = s.Single(r => r.EndsWith(sheet));
            using (Stream fileStream = asm.GetManifestResourceStream(file))
            {
                using (ExcelEngine excelEngine = new ExcelEngine())
                {
                    IApplication application = excelEngine.Excel;
                    application.DefaultVersion = ExcelVersion.Xlsx;

                    IWorkbook workbook = application.Workbooks.Open(fileStream);
                    if (workbook != null)
                    {
                        foreach (IWorksheet ws in workbook.Worksheets)
                        {
                            int row = 1;
                            while (!ws[++row,1].IsBlank)
                            {
                                Club club = new Club(session, ws, row);
                                session.Load(club);
                            }
                        }
                    }
                }
            }
        }
    }
}
