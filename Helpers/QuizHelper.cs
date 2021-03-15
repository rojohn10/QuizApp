using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using QuizApp.DataModels;

namespace QuizApp.Helpers
{
    public class QuizHelper
    {
        List<Question> History;
        List<Question> Geography;
        List<Question> Programming;
        List<Question> Business;
        List<Question> Engineering;
        List<Question> Space;

        public string GetTopicDescription(string topic)
        {
            string topicDescription = "";

            switch (topic)
            {
                case "History":
                    topicDescription = "History is the study of the past as it is described in written documents. " +
                        "Events occurring before written record are considered prehistory. It is an umbrella term " +
                        "that relates to past events as well as the memory, discovery, collection, organization, " +
                        "presentation, and interpretation of information about these events.";
                    break;

                case "Geography":
                    topicDescription = "Geography is the study of places and the relationships between people and " +
                        "their environments. Geographers explore both the physical properties of Earth's surface " +
                        "and the human societies spread across it.";
                    break;

                case "Space":
                    topicDescription = "The concept of space is considered to be of fundamental importance to an " +
                        "understanding of the physical universe. However, disagreement continues between philosophers " +
                        "over whether it is itself an entity, a relationship between entities, or part of a conceptual framework.";
                    break;

                case "Engineering":
                    topicDescription = "It is the use of scientific principles to design and build machines, structures, " +
                        "and other items, including bridges, tunnels, roads, vehicles, and buildings. The discipline " +
                        "of engineering encompasses a broad range of more specialized fields of engineering, each with " +
                        "a more specific emphasis on particular areas of applied mathematics, applied science, and types of application";
                    break;

                case "Programming":
                    topicDescription = "It is the process of designing and building an executable computer program to accomplish " +
                        "a specific computing result or to perform a specific task. Programming involves tasks such as: analysis, " +
                        "generating algorithms, profiling algorithms' accuracy and resource consumption, and the implementation of " +
                        "algorithms in a chosen programming language";
                    break;

                case "Business":
                    topicDescription = "A business is defined as an organization or enterprising entity engaged in commercial, industrial, " +
                        "or professional activities. Businesses can be for-profit entities or they can be non-profit organizations that " +
                        "operate to fulfill a charitable mission or further a social cause. ";
                    break;

                default:
                    break;
            }

            return topicDescription;
        }

        public List<Question> GetQuizQuestion(string topic)
        {
            List<Question> quizList = new List<Question>();


            switch (topic)
            {
                case "History":
                    InitializeHistory();
                    quizList = History;
                    break;

                case "Geography":
                    InitializeHistory();
                    quizList = Geography;
                    break;

                case "Space":
                    InitializeHistory();
                    quizList = Space;
                    break;

                case "Programming":
                    InitializeHistory();
                    quizList = Programming;
                    break;

                case "Business":
                    InitializeHistory();
                    quizList = Business;
                    break;

                case "Engineering":
                    InitializeHistory();
                    quizList = Engineering;
                    break;

                default:
                    break;
            }

            return quizList;
        }

        void InitializeHistory()
        {
            History = new List<Question>();
            History.Add(new Question { QuizQuestion = "Whose death sparked World War I?",Answer = "Archduke Franz Ferdinand", OptionA = "Kaiser Wilhelm", OptionB = "Archbishop Ussher", OptionC = "Queen Victoria", OptionD = "Archduke Franz Ferdinand" });
            History.Add(new Question { QuizQuestion = "Which of these battles did not involve Roman soldiers", Answer = "Thermopylae", OptionA = "Arretium", OptionB = "Chalons", OptionC = "Cannae", OptionD = "Thermopylae" });
            History.Add(new Question { QuizQuestion = "Who was Karl Marx’s associate and fellow political theoretician?", Answer = "Friedrich Engels", OptionA = "Friedrich Nietzsche", OptionB = "Friedrich II", OptionC = "Friedrich Engels", OptionD = "Friedrich Reich" });
            History.Add(new Question { QuizQuestion = "Which book was written by Niccolò Machiavelli?", Answer = "The Prince", OptionA = "The Once and Future King", OptionB = "The Prince", OptionC = "The Good Earth", OptionD = "War and Peace" });
            History.Add(new Question { QuizQuestion = "When was the first Nobel Prize in economics awarded?", Answer = "1969", OptionA = "1969", OptionB = "1949", OptionC = "1909", OptionD = "1929" });
        }

        void InitializeGeography()
        {
            Geography = new List<Question>();
            Geography.Add(new Question { QuizQuestion = "What is the largest country in the world (by Area)?", Answer = "Russia", OptionA = "Russia", OptionB = "Canada", OptionC = "United Sates", OptionD = "China" });
            Geography.Add(new Question { QuizQuestion = "Which of the following countries does NOT have a population exceeding 200 million?", Answer = "Nigeria", OptionA = "Brazil", OptionB = "Indonesia", OptionC = "Pakistan", OptionD = "Nigeria" });
            Geography.Add(new Question { QuizQuestion = "Muscat is the capital of which country?", Answer = "Oman", OptionA = "Oman", OptionB = "Jordan", OptionC = "Yemen", OptionD = "Bahrain" });
            Geography.Add(new Question { QuizQuestion = "Which is the world's smallest continent (by area)?", Answer = "Oceania", OptionA = "Oceania", OptionB = "Antractica", OptionC = "South America", OptionD = "Europe" });
            Geography.Add(new Question { QuizQuestion = "Which of the following countries is NOT a member state of the European Union?", Answer = "Norway", OptionA = "Finland", OptionB = "Sweden", OptionC = "Norway", OptionD = "Denmark" });

        }

        void InitializeSpace()
        {
            Space = new List<Question>();
            Space.Add(new Question { QuizQuestion = "Who was the first man to ever walk on the Moon?", Answer = "Niel Armstrong", OptionA = "Uchenna Nnodim", OptionB = "Niel Armstrong", OptionC = "Benjamin Franklin", OptionD = "Pele Pele" });
            Space.Add(new Question { QuizQuestion = "The coldest and farthest Planet from the Sun is ?", Answer = "Pluto", OptionA = "Earth", OptionB = "Pluto", OptionC = "Neptune", OptionD = "Saturn" });
            Space.Add(new Question { QuizQuestion = "The galaxy that contains Solar System which Earth belongs to is called what?", Answer = "Milky Way", OptionA = "Chocolate Path", OptionB = "Phantom Zone", OptionC = "Milky Way", OptionD = "Solar Container" });
            Space.Add(new Question { QuizQuestion = "How many days does it take the Earth to complete her orbit", Answer = "365 Days", OptionA = "365 Days", OptionB = "30 Days", OptionC = "272 Days", OptionD = "None of the Above" });
            Space.Add(new Question { QuizQuestion = "An explosion which leads to gigantic explosion throwing star's outer layers are thrown out is called", Answer = "Supernova", OptionA = "Black hole", OptionB = "Double ring", OptionC = "Massive Explosion", OptionD = "Supernova" });

        }
    }
}
            
    
