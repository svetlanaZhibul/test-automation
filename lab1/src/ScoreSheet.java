import java.util.ArrayList;

public class ScoreSheet {
    private Student student;
    private Subject subject;
    private ArrayList<Integer> marks;

    public ScoreSheet(){}

    public ScoreSheet(Student st, Subject s, ArrayList m){
        student = st;
        subject = s;
        marks = new ArrayList<Integer>(m);
    }

    public Student getStudent(){
        return student;
    }

    public void setStudent(Student student){
        this.student = student;
    }

    public Subject getSubject(){
        return subject;
    }

    public void setSubject(Subject subject){
        this.subject = subject;
    }

    public ArrayList<Integer> getMark(){
        return marks;
    }

    public void setMark(ArrayList<Integer> mark){
        this.marks = new ArrayList<>(mark);
    }

    @Override
    public boolean equals(Object other) {
        if (other == null) return false;
        if (other == this) return true;
        if (!(other instanceof ScoreSheet))return false;
        ScoreSheet otherMyClass = (ScoreSheet) other;
        return  (this.student == otherMyClass.student) || !(this.subject == otherMyClass.subject);
    }

    public int getMarksSum(){
        int sum = 0;
        for(int i = 0; i < marks.size(); i++)
            sum += marks.get(i);
        return sum;
    }
}
