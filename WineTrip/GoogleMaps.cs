using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WineTrip.DataModel;

namespace WineTrip
{
    public class GoogleMaps
    {
 

        public static void VerifyAdress(Event evnt)
        {
            string apiKey = ConfigurationManager.AppSettings["VerifyAdressKey"];            
            string url = $"https://maps.googleapis.com/maps/api/geocode/xml?address={evnt.address}&key={apiKey}";
            XmlDocument doc = FetchXMLData(url);
            evnt.locationStatus = doc.SelectSingleNode("GeocodeResponse/status").InnerText;
            evnt.address = doc.SelectSingleNode("GeocodeResponse/result/formatted_address").InnerText;
            evnt.GPSLocation = $"{doc.SelectSingleNode("GeocodeResponse/result/geometry/location/lat").InnerText},{doc.SelectSingleNode("GeocodeResponse/result/geometry/location/lng").InnerText}";
            #region xml
            /*
            <?xml version="1.0" encoding="UTF-8"?>
            -<GeocodeResponse>
                <status>OK</status>
                -<result>
                    <type>street_address</type>
                    <formatted_address>Meikade 75, 6744 TC Ederveen, Netherlands</formatted_address>
                    -<address_component>
                        <long_name>75</long_name>
                        <short_name>75</short_name>
                        <type>street_number</type>
                    </address_component>
                    -<address_component>
                        <long_name>Meikade</long_name>
                        <short_name>Meikade</short_name>
                        <type>route</type>
                    </address_component>
                    -<address_component>
                        <long_name>Ederveen</long_name>
                        <short_name>Ederveen</short_name>
                        <type>locality</type>
                        <type>political</type>
                    </address_component>
                    -<address_component>
                        <long_name>Ede</long_name>
                        <short_name>Ede</short_name>
                        <type>administrative_area_level_2</type>
                        <type>political</type>
                    </address_component>
                    -<address_component>
                        <long_name>Gelderland</long_name>
                        <short_name>GE</short_name>
                        <type>administrative_area_level_1</type>
                        <type>political</type>
                    </address_component>
                    -<address_component>
                        <long_name>Netherlands</long_name>
                        <short_name>NL</short_name>
                        <type>country</type>
                        <type>political</type>
                    </address_component>
                    -<address_component>
                        <long_name>6744 TC</long_name>
                        <short_name>6744 TC</short_name>
                        <type>postal_code</type>
                    </address_component>
                    -<geometry>
                        -<location>
                            <lat>52.0644881</lat>
                            <lng>5.6003042</lng>
                        </location>
                        <location_type>ROOFTOP</location_type>
                        -<viewport>
                            -<southwest>
                                <lat>52.0631391</lat>
                                <lng>5.5989552</lng>
                            </southwest>
                            -<northeast>
                                <lat>52.0658371</lat>
                                <lng>5.6016532</lng>
                            </northeast>
                        </viewport>
                    </geometry>
                    <place_id>ChIJN_gPPYRNxkcRxZOYa-wXhl8</place_id>
                </result>
            </GeocodeResponse>
            */
#endregion
        }

        public static void GetSingleEventMap(Event evnt)
        {
            string apiKey = ConfigurationManager.AppSettings["GetSingleEventMap"]; ;
            string url = $"https://maps.googleapis.com/maps/api/staticmap?size=800x600&maptype=roadmap&markers=color:blue|label:S|{evnt.GPSLocation}&key={apiKey}";
            evnt.map = FetchPNGImage(url);
        }

        public static void GetTransferMap(Transfer transfer)
        {
            string apiKeyDirections = ConfigurationManager.AppSettings["GetTransferMap"];
            string url = $"https://maps.googleapis.com/maps/api/directions/xml?origin={transfer.startEvent.GPSLocation}&destination={transfer.endEvent.GPSLocation}&mode=driving&key={apiKeyDirections}";
            XmlDocument doc = FetchXMLData(url);
            string encodedPolyLine = doc.SelectSingleNode("DirectionsResponse/route/overview_polyline/points").InnerText;
             string apiKeyStaticMap = ConfigurationManager.AppSettings["GetSingleEventMap"];
            url = $"https://maps.googleapis.com/maps/api/staticmap?size=800x600&maptype=roadmap&markers=color:blue|label:B|{transfer.startEvent.GPSLocation}&markers=color:blue|label:T|{transfer.endEvent.GPSLocation}&path=enc%3A{encodedPolyLine}&key={apiKeyStaticMap}";
            transfer.map = FetchPNGImage(url);
        }

        public static bool GetTimeAndDistance(Transfer transfer)
        {
            const string apiKey = "AIzaSyCv7ehFKbceOdWqVvFulZI9RJRaTVd2JVc";
            if (transfer.startEvent.GPSLocation == null || transfer.endEvent.GPSLocation == null)
                return false;
            string originLocation = transfer.startEvent.GPSLocation.Trim();
            string destinationLocation = transfer.endEvent.GPSLocation.Trim();
            string url = $"https://maps.googleapis.com/maps/api/distancematrix/xml?origins={originLocation}&destinations={destinationLocation}&key={apiKey}";
            XmlDocument doc = FetchXMLData(url);
            XmlNode element = doc.SelectSingleNode("DistanceMatrixResponse/row/element"); // we will only ever have one row
            string duration = element.SelectSingleNode("duration/value").InnerText;
            int value;
            if (int.TryParse(duration, out value))
                transfer.duration = value/60;
            transfer.distance = element.SelectSingleNode("distance/text").InnerText;
            return true;
            #region xml
            /*
            <DistanceMatrixResponse>
                <status>OK</status>
                <origin_address>Washington, DC, USA</origin_address>
                <destination_address>New York, NY, USA</destination_address>
                <row>
                    -<element>
                        <status>OK</status>
                        -<duration>
                        <value>13673</value>
                            <text>3 hours 48 mins</text>
                            </duration>
                        -<distance>
                            <value>361721</value>
                            <text>362 km</text>
                        </distance>
                    </element>
                </row>
                </DistanceMatrixResponse>
            */
            #endregion
        }

        private static XmlDocument FetchXMLData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            XmlDocument doc = new XmlDocument();
            doc.Load(resStream);
            return doc;
        }

        private static Bitmap FetchPNGImage(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new Bitmap(response.GetResponseStream());
        }
    }
}
