import java.util.HashMap;
import java.util.Map;

public class Subject implements MeanCounting{
    private String name;
    private Map<Student, ScoreSheet> scoreSheets;

    public Subject(){}

    public Subject(String name){
        this.name = name;
        scoreSheets = new HashMap<>();
    }

    public String getName(){
        return name;
    }

    public void setName(String name){
        this.name = name;
    }

    public Map<Student, ScoreSheet> getScore(){
        return scoreSheets;
    }

    public void setScore(Student student, ScoreSheet scoreSheet){
        scoreSheets.put(student, scoreSheet);
    }

    @Override
    public boolean equals(Object other) {
        if (other == null) return false;
        if (!(other instanceof Subject))return false;
        Subject otherMyClass = (Subject) other;
        return  (this.name.equals(otherMyClass.name));
    }

    public double findMean(){
        int n = 0;
        double sum = 0;
        for (Student s:scoreSheets.keySet()){
            sum += getScore().get(s).getMarksSum();
            n += getScore().get(s).getMark().size();
        }
        return (n>0) ? sum/n : -1;
    }
}
