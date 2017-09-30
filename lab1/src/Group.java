import java.util.ArrayList;
import java.util.List;

public class Group implements MeanCounting{
    private String number;
    private String faculty;
    private List<Student> studentList;

    public Group(){}

    public Group(String number, String faculty) {
        this.number = number;
        this.faculty = faculty;
        studentList = new ArrayList<>();
    }

    public void setFaculty(String faculty) {
        this.faculty = faculty;
    }

    public String getFaculty() {
        return faculty;
    }

    public String getNumber() {
        return number;
    }

    public void setNumber(String number) {
        this.number = number;
    }

    public void setStudentList(List<Student> studentList) {
        this.studentList = studentList;
    }

    public void addStudentToList(Student student) {
        this.studentList.add(student);
    }

    public List<Student> getStudentList() {
        return studentList;
    }

    @Override
    public boolean equals(Object other) {
        if (other == null) return false;
        if (!(other instanceof Group))return false;
        Group otherMyClass = (Group) other;
        if (!(this.number.equals(otherMyClass.number)
                && this.faculty.equals(otherMyClass.faculty))) return false;
        return true;
    }

    public double findMean(){
        double sum = 0;
        for (Student s : studentList){
            sum += s.findMean();
        }
        return (studentList.size()>0) ? sum/studentList.size() : -1;
    }
}
