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
            StringBuilder htmlText = new StringBuilder();
            htmlText.AppendLine($"<body>{Resources.StyleSheet} <p>Dear {member.ShortName},</p><p>Below follows an overview of purchases you made and expenses that were made on our winetrip. Your payments are included as well.</p>");
            foreach (Event evnt in trip.events)
            {
                if (evnt.TotalBottleCount(member) > 0)
                {
                    htmlText.AppendLine($"<p><b>{trip.startDate.AddDays(evnt.start.day).ToShortDateString()}: {evnt.name}</b></p>");
                    CreateHtmlEventWinePurchases(htmlText, evnt, member);
                    CreateHtmlEventWinePayments(htmlText, evnt, member);
                    htmlText.AppendLine("<HR>");
                }
                if (evnt.expenseParticipatingMembers.Contains(member) || evnt.expensePayments.Where( x => x.member == member).Count() > 0)
                {
                    htmlText.AppendLine($"<p><b>{trip.startDate.AddDays(evnt.start.day).ToShortDateString()}: {evnt.name}</b></p>");
                    CreateHtmlEventExpense(htmlText, evnt, member);
                    CreateHtmlEventExpensePayments(htmlText, evnt, member);
                    htmlText.AppendLine("<HR>");
                }
            }
            CreateHtmlBalance(htmlText, trip, member);
            htmlText.AppendLine("</body>");
            return htmlText.ToString();
        }

        private static void CreateHtmlEventWinePurchases(StringBuilder htmlText, Event evnt, Member member)
        {
            htmlText.AppendLine("<table>");
            htmlText.AppendLine("<tr class=\"toprow\"><td>Count</td><td>Description</td><td>Price</td></tr>");
            foreach (Bottle bottle in evnt.bottles)
            {
                int count = bottle.orders.Where(x => x.member == member).Sum(x => x.count);
                if (count > 0)
                {
                    htmlText.AppendLine($"<tr><td align=right>{count}</td><td align=left>{bottle.name} </td><td align=right>{count * bottle.price:###0.00}</td></tr>");
                }
            }
            htmlText.AppendLine($"<tr class=\"bottomrow\"><td align=right>{evnt.TotalBottleCount(member)}</td><td></td><td align=right>{evnt.TotalPrice(member):###0.00}</td></tr>");
            htmlText.AppendLine("</table>");
        }

        private static void CreateHtmlEventWinePayments(StringBuilder htmlText, Event evnt, Member member)
        {
            decimal payed = evnt.tastingPayments.Where(x => x.member == member).Sum(x => x.amount);
            htmlText.AppendLine($"<p>Amount payed: {payed:###0.00}</p>");
        }


        private static void CreateHtmlEventExpense(StringBuilder htmlText, Event evnt, Member member)
        {
            if (evnt.expenseParticipatingMembers.Contains(member))
            { 
                decimal expense = evnt.expense / evnt.expenseParticipatingMembers.Count;
                htmlText.AppendLine($"<p>{evnt.expenseDescription}</p><p>Total expenses (group) made: {evnt.expense:###0.00}, your share: {expense:###0.00}</p>");
            }
        }

        private static void CreateHtmlEventExpensePayments(StringBuilder htmlText, Event evnt, Member member)
        {
            decimal payed = evnt.expensePayments.Where(x => x.member == member).Sum(x => x.amount);
            htmlText.AppendLine($"<p>Amount payed: {payed}</p>");
        }

        private static void CreateHtmlBalance(StringBuilder htmlText, Trip trip, Member member)
        {
            int reds = trip.events.SelectMany(x => x.bottles).Where(x => x.wine == Bottle.Wine.red).Select(b => b.orders.Where(o => o.member == member).Sum(o => o.count)).Sum(o => o);
            int whites = trip.events.SelectMany(x => x.bottles).Where(x => x.wine == Bottle.Wine.white).Select(b => b.orders.Where(o => o.member == member).Sum(o => o.count)).Sum(o => o);
            int roses = trip.events.SelectMany(x => x.bottles).Where(x => x.wine == Bottle.Wine.rose).Select(b => b.orders.Where(o => o.member == member).Sum(o => o.count)).Sum(o => o);
            int sparklings = trip.events.SelectMany(x => x.bottles).Where(x => x.isSparklingWine).Select(b => b.orders.Where(o => o.member == member).Sum(o => o.count)).Sum(o => o);
            int desserts = trip.events.SelectMany(x => x.bottles).Where(x => x.isDessertWine).Select(b => b.orders.Where(o => o.member == member).Sum(o => o.count)).Sum(o => o);
            int totalNUmberOfBottles = trip.events.SelectMany(x => x.bottles).Select(b => b.orders.Where(o => o.member == member).Sum(o => o.count)).Sum(o => o);

            var purchase = trip.events.SelectMany(x => x.bottles).Select(bottle => new { count = bottle.orders.Where(y => y.member == member).Sum(x => x.count), price = bottle.price });
            decimal spendOnWine = purchase.Sum(x => x.price * x.count);
            decimal expenses = trip.events.Sum(e => e.expenseParticipatingMembers.Contains(member) ? e.expense / e.expenseParticipatingMembers.Count : 0);
            decimal payed = trip.events.Sum(e => e.tastingPayments.Where(t => t.member == member).Sum(x => x.amount) + e.expensePayments.Where(t => t.member == member).Sum(x => x.amount));

            htmlText.AppendLine("<table>");
            htmlText.AppendLine($"<tr><td align=left></td><td># of bottles</td></tr>");
            htmlText.AppendLine($"<tr><td align=left>Red wines:</td><td align=right>{reds}</td></tr>");
            htmlText.AppendLine($"<tr><td align=left>White wines:</td><td align=right>{whites}</td></tr>");
            htmlText.AppendLine($"<tr><td align=left>Rose wines:</td><td align=right>{roses}</td></tr>");
            htmlText.AppendLine($"<tr><td align=left>Sparkling wines:</td><td align=right>{sparklings}</td></tr>");
            htmlText.AppendLine($"<tr><td align=left>Dessert wines:</td><td align=right>{desserts}</td></tr>");
            htmlText.AppendLine($"<tr><td align=left>Total</td><td align=right>{totalNUmberOfBottles}</td></tr>");
            htmlText.AppendLine("</table>");

            htmlText.AppendLine("<HR>");

            htmlText.AppendLine("<table>");
            htmlText.AppendLine($"<tr><td align=left>Total spend on wine:</td><td align=right> {spendOnWine:###0.00}</td></tr>");
            htmlText.AppendLine($"<tr><td align=left>Total expenses:</td><td align=right> {expenses:###0.00}</td></tr>");
            htmlText.AppendLine($"<tr><td align=left>Total payed:</td><td align=right> {payed:###0.00}</td></tr>");
            htmlText.AppendLine($"<tr><td align=left>Balance:</td><td align=right> {spendOnWine + expenses - payed:###0.00}</td></tr>");
            htmlText.AppendLine("</table>");
        }
    }
}
