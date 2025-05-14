import { Checkbox, List } from "antd";
import "./Ilac.css";
import IlacDeleteButton from "./IlacDeleteButton";
import DeleteILac from "../../api/DeleteIlac";

const Ilac = ({ ilac, checkedList, setCheckedList, ilaclar, setIlaclar, filteredList, setFilteredList }) => {
  const handleCheckboxChange = () => {
    if (checkedList.some(item => item.id === ilac.id)) {
      setCheckedList(checkedList.filter(item => item.id !== ilac.id));
    } else {
      setCheckedList([...checkedList, ilac]);
    }
  };

  const onDeleteButtonClick = async () => {
        const deleteResult = await DeleteILac(ilac.id);
        console.log(deleteResult);
        setFilteredList([filteredList.filter(item => item.id !== ilac.id)]);
        setIlaclar(ilaclar.filter(item => item.id !== ilac.id));
  }

  return (
    <List.Item>
      <div className="ilac-item">
        <div className="ilac-item-name">{ilac.adi}</div>
        <div className="ilac-item-stok">Stok:{ilac.stokDurumu}</div>
        <div className="ilac-item-price">{ilac.fiyati} TL</div>
        <Checkbox
          className="ilac-item-checkbox"
          checked={checkedList.some(item => item.id === ilac.id)}
          onChange={handleCheckboxChange}
        />
        <IlacDeleteButton  
        className="item-delete-button"
        onDeleteButtonClick={onDeleteButtonClick}  />
      </div>
    </List.Item>
  );
};

export default Ilac;
