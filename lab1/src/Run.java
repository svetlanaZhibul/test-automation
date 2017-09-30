import java.util.ArrayList;

/**
 * Program prints average mark values due to university 'units' (Students,
 * Subjects, Faculties, Groups and whole University).
 *
 * The data to be executed is taken from 'list.txt' file.
 *
 */

public class Run {

    public static void main(String[] args) {

        ArrayList<ScoreSheet> ssh = new ArrayList<>();
        ArrayList<Student> stds = new ArrayList<>();
        ArrayList<Subject> subs = new ArrayList<>();
        ArrayList<Faculty> faculties = new ArrayList<>();
        ArrayList<Group> groups = new ArrayList<>();
        University uni = new University();

        ReadScoreLogic.scanFile(ssh, stds, subs, uni, faculties, groups);

        for (Student st : stds) {
             System.out.println("Average mark " + st.findMean() + " for " + st.getName() + ", id: " + st.getId());
        }
        System.out.println();
        for (Subject sub : subs) {
            System.out.println("Average mark " + sub.findMean() + " for " + sub.getName() + " subject");
        }
        System.out.println();
        for(Group g : groups){
            System.out.println("Average mark among " + g.getNumber() + " group on " + g.getFaculty() + ": " + g.findMean());
        }
        System.out.println();
        for(Faculty f : faculties){
            System.out.println("Average mark among " + f.getName()+" faculty groups: " + f.findMean());
        }
        System.out.println();
        System.out.println("Average mark among university faculties: " + uni.findMean());
    }

}
