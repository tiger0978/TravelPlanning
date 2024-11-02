﻿using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Utility
{
    public class PolylineEncoder
    {
        /// <summary>
		/// Encodes the list of coordinates to a Google Maps encoded coordinate string.
		/// </summary>
		/// <param name="coordinates">The coordinates.</param>
		/// <returns>Encoded coordinate string</returns>
		public static string EncodeCoordinates(IEnumerable<PointLatLng> coordinates)
        {
            double oneEFive = Convert.ToDouble(1e5);

            int plat = 0;
            int plng = 0;
            StringBuilder encodedCoordinates = new StringBuilder();

            foreach (PointLatLng coordinate in coordinates)
            {
                // Round to 5 decimal places and drop the decimal
                int late5 = (int)(coordinate.Lat * oneEFive);
                int lnge5 = (int)(coordinate.Lng * oneEFive);

                // Encode the differences between the coordinates
                encodedCoordinates.Append(EncodeSignedNumber(late5 - plat));
                encodedCoordinates.Append(EncodeSignedNumber(lnge5 - plng));

                // Store the current coordinates
                plat = late5;
                plng = lnge5;
            }

            return encodedCoordinates.ToString();
        }

        /// <summary>
        /// Decode encoded polyline information to a collection of <see cref="LatLng"/> instances.
        /// </summary>
        /// <param name="value">ASCII string</param>
        /// <returns></returns>
        public static IEnumerable<PointLatLng> Decode(string value)
        {
            //decode algorithm adapted from saboor awan via codeproject:
            //http://www.codeproject.com/Tips/312248/Google-Maps-Direction-API-V3-Polyline-Decoder
            //note the Code Project Open License at http://www.codeproject.com/info/cpol10.aspx

            if (value == null || value == "") return new List<PointLatLng>(0);

            char[] polylinechars = value.ToCharArray();
            int index = 0;

            int currentLat = 0;
            int currentLng = 0;
            int next5bits;
            int sum;
            int shifter;

            List<PointLatLng> poly = new List<PointLatLng>();

            while (index < polylinechars.Length)
            {
                // calculate next latitude
                sum = 0;
                shifter = 0;
                do
                {
                    next5bits = (int)polylinechars[index++] - 63;
                    sum |= (next5bits & 31) << shifter;
                    shifter += 5;
                } while (next5bits >= 32 && index < polylinechars.Length);

                if (index >= polylinechars.Length)
                    break;

                currentLat += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);

                //calculate next longitude
                sum = 0;
                shifter = 0;
                do
                {
                    next5bits = (int)polylinechars[index++] - 63;
                    sum |= (next5bits & 31) << shifter;
                    shifter += 5;
                } while (next5bits >= 32 && index < polylinechars.Length);

                if (index >= polylinechars.Length && next5bits >= 32)
                    break;

                currentLng += (sum & 1) == 1 ? ~(sum >> 1) : (sum >> 1);
                PointLatLng point = new PointLatLng(
                    lat: Convert.ToDouble(currentLat) / 100000.0,
                    lng: Convert.ToDouble(currentLng) / 100000.0
                );
                poly.Add(point);
            }

            return poly;
        }

        /// <summary>
        /// Encode a signed number in the encode format.
        /// </summary>
        /// <param name="num">The signed number</param>
        /// <returns>The encoded string</returns>
        private static string EncodeSignedNumber(int num)
        {
            int sgn_num = num << 1; //shift the binary value
            if (num < 0) //if negative invert
            {
                sgn_num = ~(sgn_num);
            }
            return (EncodeNumber(sgn_num));
        }

        /// <summary>
        /// Encode an unsigned number in the encode format.
        /// </summary>
        /// <param name="num">The unsigned number</param>
        /// <returns>The encoded string</returns>
        private static string EncodeNumber(int num)
        {
            StringBuilder encodeString = new StringBuilder();
            while (num >= 0x20)
            {
                encodeString.Append((char)((0x20 | (num & 0x1f)) + 63));
                num >>= 5;
            }
            encodeString.Append((char)(num + 63));
            // All backslashes needs to be replaced with double backslashes
            // before being used in a Javascript string.
            return encodeString.ToString();
        }
    }
}
