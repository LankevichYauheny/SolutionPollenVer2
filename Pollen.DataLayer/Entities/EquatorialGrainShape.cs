using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;// ����� ���������� ����������� ������� ��������� 
                                            //��������� ������������ ��������� ������������� ������� � ������ � ������� ���������. 
using System.ComponentModel.DataAnnotations.Schema;

namespace Pollen.DataLayer.Entities
{
    [Table("EquatorialGrainShapes")]
    public class EquatorialGrainShape
    {
        public EquatorialGrainShape()
        {
            PlantTypes = new List<PlantType>();
        }
        [Key] //��������� �������� � �������� ���������� �����
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        //������������� ��������
        public List<PlantType> PlantTypes { get; set; }
    }
}
