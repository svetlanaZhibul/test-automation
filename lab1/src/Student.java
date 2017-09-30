import java.util.HashMap;
import java.util.Map;

public class Student implements MeanCounting{
    private int id;
    private String fio;
    private String group;
    private String faculty;
    private Map<Subject, ScoreSheet> scoreSheets;

    public Student() {}

    public Student(int id, String fio, String group, String faculty){
        this.id = id;
        this.fio = fio;
        this.group = group;
        this.faculty = faculty;
        scoreSheets = new HashMap<>();
    }

    public Map<Subject, ScoreSheet> getScore() {
        return scoreSheets;
    }

    public void setScore(Subject subject, ScoreSheet scoreSheet) {
        scoreSheets.put(subject, scoreSheet);
    }

    public String getFaculty() {
        return faculty;
    }

    public String getGroup() {
        return group;
    }

    public String getName() {
        return fio;
    }

    public int getId() {
        return id;
    }

    @Override
    public boolean equals(Object other) {
        if (other == null) return false;
        if (!(other instanceof Student))return false;
        Student otherMyClass = (Student) other;
        if (this.id != otherMyClass.id) return false;
        else if(!(this.fio.equals(otherMyClass.fio)
                && this.group.equals(otherMyClass.group)
                && this.faculty.equals(otherMyClass.faculty))) return false;
        return true;
    }

    public double findMean(){
        int n = 0;
        double sum = 0;
        for (Subject s:scoreSheets.keySet()){
            sum += getScore().get(s).getMarksSum();
            n += getScore().get(s).getMark().size();
        }
        return (n>0) ? sum/n : 0;
    }

}
