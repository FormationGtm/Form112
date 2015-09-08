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
        /// <summary>
        /// Helper qui permet de construire le bloc html d'un commentaire et de gérer l'identation du commentaire s'il s'agit d'une réponse.
        /// On affiche le nom de l'auteur du commentaire, la date réduite de post du commentaire, 
        /// un lien pour répondre (qui envoi vers l'ancre du formulaire de réponse), et le commentaire en lui même.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="Nom"></param>
        /// <param name="Date"></param>
        /// <param name="commentaire"></param>
        /// <param name="count"></param>
        /// <returns>un chaine de caractère correspondant au bloc html du commentaire</returns>
        public static string CommentaireHelper(this HtmlHelper self, int id, string Nom, string Date, string commentaire, int count)
        {
            var nbColumn = 12 - count;
            var commentPanel = new TagBuilder("div");
            commentPanel.AddCssClass(String.Format("comment-panel", nbColumn));
            if (count > 0) {
                commentPanel.AddCssClass(String.Format("comment-reply-offset-{0} ", count));
            }
            commentPanel.Attributes.Add("id", id.ToString());

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