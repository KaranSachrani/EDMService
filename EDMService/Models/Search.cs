using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDMService.Models
{

    public class Search
    {
        public string BlockCodeName;
        public string WardName;
        public string UCName;
        public string Name;
        public string FatherName;
        public string Name_Urdu;
        public string FkVoterID;
        public string Booth_Number;
        public string PS_Number;
        public string Polling_station;
        public string Cnic;
        public string Address_Urdu;
        public string FatherName_Urdu;
        public string Polling_station_Urdu;
        public string Silsila;
        public string Gharana;
        public string PK_Pollingstation;
        public string PoliticalParty;
        public string PollingCenterID;
        public bool error = true;
        public bool found = false;

        public Search(){}

        public Search(string blockCodeName, string wardName, string ucName, string name, string fatherName, string nameUrdu, string fkVoterId, string boothNumber, string psNumber, string pollingStation, string cnic, string addressUrdu, string fatherNameUrdu, string pollingStationUrdu, string silsila, string gharana, string pkPollingstation, string politicalParty, string pollingCenterId,bool f)
        {
            BlockCodeName = blockCodeName;
            WardName = wardName;
            UCName = ucName;
            Name = name;
            FatherName = fatherName;
            Name_Urdu = nameUrdu;
            FkVoterID = fkVoterId;
            Booth_Number = boothNumber;
            PS_Number = psNumber;
            Polling_station = pollingStation;
            Cnic = cnic;
            Address_Urdu = addressUrdu;
            FatherName_Urdu = fatherNameUrdu;
            Polling_station_Urdu = pollingStationUrdu;
            Silsila = silsila;
            Gharana = gharana;
            PK_Pollingstation = pkPollingstation;
            PoliticalParty = politicalParty;
            PollingCenterID = pollingCenterId;
            found = f;
        }

        public Search(bool e)
        {
            error = e;
        }

        public string BlockCodeName1
        {
            get { return BlockCodeName; }
            set { BlockCodeName = value; }
        }

        public string WardName1
        {
            get { return WardName; }
            set { WardName = value; }
        }

        public string UcName
        {
            get { return UCName; }
            set { UCName = value; }
        }

        public string Name1
        {
            get { return Name; }
            set { Name = value; }
        }

        public string FatherName1
        {
            get { return FatherName; }
            set { FatherName = value; }
        }

        public string NameUrdu
        {
            get { return Name_Urdu; }
            set { Name_Urdu = value; }
        }

        public string FkVoterId
        {
            get { return FkVoterID; }
            set { FkVoterID = value; }
        }

        public string BoothNumber
        {
            get { return Booth_Number; }
            set { Booth_Number = value; }
        }

        public string PsNumber
        {
            get { return PS_Number; }
            set { PS_Number = value; }
        }

        public string PollingStation
        {
            get { return Polling_station; }
            set { Polling_station = value; }
        }

        public string Cnic1
        {
            get { return Cnic; }
            set { Cnic = value; }
        }

        public string AddressUrdu
        {
            get { return Address_Urdu; }
            set { Address_Urdu = value; }
        }

        public string FatherNameUrdu
        {
            get { return FatherName_Urdu; }
            set { FatherName_Urdu = value; }
        }

        public string PollingStationUrdu
        {
            get { return Polling_station_Urdu; }
            set { Polling_station_Urdu = value; }
        }

        public string Silsila1
        {
            get { return Silsila; }
            set { Silsila = value; }
        }

        public string Gharana1
        {
            get { return Gharana; }
            set { Gharana = value; }
        }

        public string PkPollingstation
        {
            get { return PK_Pollingstation; }
            set { PK_Pollingstation = value; }
        }

        public string PoliticalParty1
        {
            get { return PoliticalParty; }
            set { PoliticalParty = value; }
        }

        public string PollingCenterId
        {
            get { return PollingCenterID; }
            set { PollingCenterID = value; }
        }

        public bool Error
        {
            get { return error; }
            set { error = value; }
        }

        public bool Found
        {
            get { return found; }
            set { found = value; }
        }
    }

}