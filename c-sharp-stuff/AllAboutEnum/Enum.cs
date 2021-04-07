namespace AllAboutEnum
{
    public enum SomeEnumeratedPronouns
    {
        This,
        That,
        TheOther
    }

    public enum SomeEnumeratedConjunctions
    {
        And, 
        But, 
        Or, 
        Nor, 
        For, 
        Yet, 
        So
    }

    public class AllTheEnums
    {
        public SomeEnumeratedPronouns[] Pronouns { get; set; }
        
        public SomeEnumeratedConjunctions[] Conjunctions { get; set; }
    }
}