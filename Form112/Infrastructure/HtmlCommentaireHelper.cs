using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Form112.Infrastructure
{
    public static class HtmlCommentaireHelper
    {
        public static string CommentaireHelper(this HtmlHelper self, string Nom, string Date, string commentaire, int count)
        {
            var nbColumn = 12 - count;
            var commentPanel = new TagBuilder("div");
            commentPanel.AddCssClass(String.Format("comment-panel col-sm-{0} ", nbColumn));
            if (count > 0) {
                commentPanel.AddCssClass(String.Format("col-sm-offset{0} ", count));
            }

            var commentHeader = new TagBuilder("div");
            commentHeader.AddCssClass("comment-header");

            var commentAuthorName = new TagBuilder("span");
            commentAuthorName.AddCssClass("author-name");
            commentAuthorName.InnerHtml = Nom.ToString();

            var commentDate = new TagBuilder("span");
            commentDate.AddCssClass("comment-date");
            commentDate.InnerHtml = Date.ToString();

            var commentReply = new TagBuilder("a");
            commentReply.AddCssClass("reply-arrow");
            commentReply.Attributes.Add("href", "#idFormCommentaire");

            var commentReplyArrow = new TagBuilder("i");
            commentReplyArrow.AddCssClass("fa fa-reply pull-right");
            commentReply.InnerHtml = commentReplyArrow.ToString();

            commentHeader.InnerHtml = commentAuthorName.ToString() + commentDate.ToString() + commentReply.ToString();

            var commentBody = new TagBuilder("div");
            commentBody.AddCssClass("comment-body");

            var commentBodyLeftQuote = new TagBuilder("i");
            commentBodyLeftQuote.AddCssClass("fa fa-quote-left");

            var commentBodyRightQuote = new TagBuilder("i");
            commentBodyRightQuote.AddCssClass("fa fa-quote-right");

            commentBody.InnerHtml = commentBodyLeftQuote.ToString() + " " + commentaire + " " + commentBodyRightQuote.ToString();

            commentPanel.InnerHtml = commentHeader.ToString() + commentBody.ToString();

            return (commentPanel.ToString());
        }
    }
}