using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineTrip.DataModel;
using WineTrip.Properties;

namespace WineTrip
{
    public class MemberUpdateMessage
    {
        public static string CreateMessage(Trip trip, Member member)
        {
            string htmlText = $"<body>{Resources.StyleSheet} <p>Dear {member.Name},</p><p>Below follows a list of purchases you made and costs that were made on our winetrip. Also, a list of payments you made is included.</p>";
            foreach (Event evnt in trip.events.Where(x => x.TotalBottleCount(member) > 0))
            {
                htmlText += $"<b>{trip.startDate.AddDays(evnt.start.day).ToShortDateString()}: {evnt.name}</b>";
                htmlText += CreateHtmlEventWinePurchases(evnt, member);
                htmlText += CreateHtmlEventWinePayments(evnt, member);
            }
            htmlText += "</body>" + CreateHtmlBalance(trip, member);
            return htmlText;
        }

        private static string CreateHtmlEventWinePurchases(Event evnt, Member member)
        {
            string htmlText = "<table>\n";
            htmlText += "<tr class=\"toprow\"><td>Count</td><td>Description</td><td>Price</td></tr>\n";
            foreach (Bottle bottle in evnt.bottles)
            {
                int count = bottle.orders.Where(x => x.member == member).Sum(x => x.count);
                if (count > 0)
                {
                    htmlText += $"<tr><td align=right>{count}</td><td align=left>{bottle.name} </td><td align=right>{count * bottle.price:###0.00}</td></tr> \n";
                }
            }
            htmlText += $"<tr class=\"bottomrow\"><td align=right>{evnt.TotalBottleCount(member)}</td><td></td><td align=right>{evnt.TotalPrice(member):###0.00}</td></tr>\n";
            htmlText += "</table>\n";
            return htmlText;
        }

        private static string CreateHtmlEventWinePayments(Event evnt, Member member)
        {
            decimal payed = evnt.tastingPayments.Where(x => x.member == member).Sum(x => x.amount);
            return $"<p>Amount payed: {payed}</p>";
        }

        private static string CreateHtmlBalance(Trip trip, Member member)
        {
            var purchase = trip.events.SelectMany(x => x.bottles).Select(bottle => new { count = bottle.orders.Where(y => y.member == member).Sum(x => x.count), price = bottle.price });
            return $"<p>Total number of bottles bought: {purchase.Sum(x => x.count)}</p><p>Total amount spend on wine: { purchase.Sum(x => x.price * x.count)}";
        }

    }
}
