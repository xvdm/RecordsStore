﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecordsStoreExam.View
{
    /// <summary>
    /// Логика взаимодействия для AboutPage.xaml
    /// </summary>
    public partial class AboutPage : Page
    {
        public AboutPage()
        {
            InitializeComponent();
            Width = SystemParameters.WorkArea.Width;
            Height = SystemParameters.WorkArea.Height - 100;
            InfoTextBox.Document.Blocks.Clear();
            InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("АНЕКДОТ")));

            InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("Анекдо́т (фр. anecdote — краткий рассказ об интересном случае; от греч. τὸ ἀνέκδοτоν — не опубликовано, букв. «не изданное»[1]) — фольклорный жанр, короткая смешная история, обычно передаваемая из уст в уста. Чаще всего анекдоту свойственно неожиданное смысловое разрешение в самом конце, которое и рождает смех. Это может быть игра слов или ассоциации, требующие дополнительных знаний: социальных, литературных, исторических, географических и т. д. Тематика анекдотов охватывает практически все сферы человеческой деятельности. В большинстве случаев авторы анекдотов неизвестны.")));
            InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("В качестве алгоритма формы выступает пародическое использование, имитация исторических преданий, легенд, натуральных очерков и т. п. В ходе импровизированных семиотических преобразований[2] рождается текст, который, вызывая катарсис, доставляет эстетическое удовольствие. Упрощённо говоря, анекдот — это бессознательно проступающее детское речевое творчество. Возможно, отсюда характерное старинное русское название — байка[3].")));
            InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("В России XVIII—XIX вв. (и в многочисленных языках мира до сих пор) слово «анекдот» имело несколько иное значение — это могла быть просто занимательная история о каком-нибудь известном человеке, необязательно с задачей его высмеять (ср. у Пушкина: «Дней минувших анекдоты»). Классикой того времени стали называть такие «анекдоты» про Потёмкина.\n")));
            
            InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("Этимология\nСловом «анекдот» в значении «неопубликованный»[6] в византийском лексиконе Суды X века названо не предназначенное для печати произведение Прокопия Кесарийского. В 1623 году это произведение Прокопия опубликовал Никколо Аллемани на латыни и греческом языках с цензурными купюрами во Франции по списку, обнаруженному в Ватиканской библиотеке. На латыни публикация называлась «Тайная история» (historia arcana), греческий вариант сохранил название «Анекдотов» (τὸ ἀνέκδοτоν), которое попало в энциклопедию Дидро в значении литературного жанра, истории тайных дел. Публикация 1623 года подхлестнула интерес к подцензурной части анекдотов Прокопия, в частности со стороны Пьера Дюпюи и его протеже и помощника, Антуана де Варийаса, который выпустил в 1684 году сочинение «Флорентийские анекдоты, или тайная история дома Медичи», где определил анекдот как особый исторический жанр, в котором через детали раскрывается глубинная суть событий и личностей, иначе — как тайную механику истории[7]. Вольтер в работе «Век Людовика XIV» формулирует анекдот как историческую деталь, не включенную в большое историческое повествование. В таком виде понятие анекдота пришло в Россию, где Голиковым были опубликованы «Анекдоты, касающиеся до Петра Великого», в которые вошли описания небольших событий, раскрывавших характерные черты личности императора[6].\n")));
            
            InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("Форма современных анекдотов\nФорма современных анекдотов может быть любой — стихотворная, маленькие рассказы, всего одна фраза-афоризм. Анекдот может быть даже в форме романа, например, жанр романа «Жизнь и необычайные приключения солдата Ивана Чонкина» характеризуется именно так: роман-анекдот.")));
            
            //InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("Это Заявление о защите конфиденциальности информирует пользователей о нашей политике конфиденциальности и способах ее осуществления, а также рассказывает о порядке использования персональной информации о пользователе. Структура нашего приложения такова, что его можно использовать и без необходимости называть себя или раскрывать какие-либо личные данные, однако если Вы указываете свои персональные данные, то мы считаем необходимым уведомить Вас о нашей политике в отношении их использования и хранения.")));
            //InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("Уведомление пользователя\nМы всегда ставим посетителей сайта в известность, если нам требуется получить информацию, которая позволяет установить их личность(Персональная информация), или их контактные данные. Обычно эти данные запрашиваются при регистрации. Персональная информация позволяет нам упростить использование приложения, избавив пользователей от необходимости вводить одну и ту же информацию несколько раз. Мы храним Ваш пароль, чтобы Вы могли каждый раз свободно входить в наше приложение. Регистрационные формы, представленные на нашем сайте, содержат поля для внесения информации личного характера(например, имя, e - mail адрес, почтовый адрес, сведения о возрасте, роде занятий и т.п.). Мы используем персональную информацию, переданную нам пользователем для контактов с самим пользователем, также она может быть доступна другим пользователям нашего приложения, заинтересованным в контакте с нашими посетителями. В нашем приложении находятся демографические и личные данные, также предоставленные нам самими пользователями. Они используются для составления статистических данных о наших пользователях, которые могут быть им интересны, полезны и представлены им по желанию. Советуем всем быть осторожными при предоставлении персональной информации.")));

            //InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("Согласие пользователя\nЕсли Вы не захотите зарегистрироваться, или предоставить нам свою персональную информацию, то Вы все равно сможете пользоваться большей частью ресурсов нашего приложения. Каждый пользователь нашего приложения может отказаться от получения любой информации от нас.")));

            //InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("Изменение персональной информации\nМы обеспечиваем пользователей средствами, которые позволяют им проверять точность указанных личных сведений и производить обновление этой информации. Мы не несем ответственности за достоверность предоставляемой пользователями персональной информации. На некоторые данные, например, имя пользователя, накладываются технические ограничения, связанные с резервированием некоторых имен.")));

            //InfoTextBox.Document.Blocks.Add(new Paragraph(new Run("Защита персональной информации\nВ нашем приложении действуют достаточные меры безопасности, направленные на защиту от потери, некорректного использования, несанкционированного доступа, разглашения, изменения или уничтожения персональной информации наших пользователей. Тем не менее мы не можем гарантировать абсолютной защищенности персональной информации, хранимой на сетевых ресурсах, каковым является данное приложение.")));
        }
    }
}
