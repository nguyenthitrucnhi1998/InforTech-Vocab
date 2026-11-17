using VocabLearningApp.BUS;
using VocabLearningApp.DAL.EntityModels;

namespace VocabLearningApp.GUI.Common {
    public class clsGlobalVariables {
        public static DatabaseContext DbContext = new();
        public static EnumTermType SelectedTermType = EnumTermType.FE;
    }
}
