import { Checkbox, List } from "antd";
import "./Ilac.css";
import IlacDeleteButton from "./IlacDeleteButton";

const Ilac = ({ ilac, checkedList, setCheckedList }) => {
  const handleCheckboxChange = () => {
    if (checkedList.some(item => item.id === ilac.id)) {
      setCheckedList(checkedList.filter(item => item.id !== ilac.id));
    } else {
      setCheckedList([...checkedList, ilac]);
    }
  };

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
        <IlacDeleteButton  className="item-delete-button"  />
      </div>
    </List.Item>
  );
};

export default Ilac;
