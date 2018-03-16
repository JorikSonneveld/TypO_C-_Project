namespace Typo.Model
{
    public class CourseExercise : Exercise
    {
        private readonly Course course;

        public CourseExercise(Course course)
        {
            this.course = course;
            ExerciseString = CreateExerciseString();
        }

        public override string CreateExerciseString()
        {
            return course.Text;
        }
    }
}