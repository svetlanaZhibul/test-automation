import java.util.ArrayList;
import java.util.List;

public class University implements MeanCounting{
    private List<Faculty> facultyList;

    public University(){
        facultyList = new ArrayList<>();
    }

    public void setFacultyList(List<Faculty> facultyList) {
        this.facultyList = facultyList;
    }

    public List<Faculty> getFacultyList() {
        return facultyList;
    }

    public double findMean(){
        double sum = 0;
        for (Faculty f:facultyList){
            sum += f.findMean();
        }
        return (facultyList.size()>0) ? sum/facultyList.size() : 0;
    }
}
