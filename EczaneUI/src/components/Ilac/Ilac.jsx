import { Button, Checkbox, List, Modal } from "antd";
import "./Ilac.css";
import IlacDeleteButton from "./IlacDeleteButton";
import DeleteILac from "../../api/DeleteIlac";
import { useEffect, useState } from "react";

const Ilac = ({ ilac, checkedList, setCheckedList, ilaclar, setIlaclar, filteredList, setFilteredList }) => {
  const [isWarningOpen, setIsWarningOpen] = useState(false);
  const [isInfoOpen, setIsInfoOpen] = useState(false);
  const [infoMessage, setInfoMessage] = useState("");

  useEffect(()=>{
    console.log(isInfoOpen);
  },[isInfoOpen])

  const handleCheckboxChange = () => {
    if (checkedList.some(item => item.id === ilac.id)) {
      setCheckedList(checkedList.filter(item => item.id !== ilac.id));
    } else {
      setCheckedList([...checkedList, ilac]);
    }
  };

  const DeleteIlacFunc = async () => {
    try{
      await DeleteILac(ilac.id);
      setFilteredList(filteredList.filter(item => item.id !== ilac.id));
      setIlaclar(ilaclar.filter(item => item.id !== ilac.id));
      setInfoMessage("Ilac Silindi");
    }catch{
      setInfoMessage("Ilac Silinemedi");
    }
  };

  const onDeleteButtonClick = () => {
    setIsWarningOpen(true);
  };

  return (
    <>
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
            onDeleteButtonClick={onDeleteButtonClick} />
        </div>
      </List.Item>
      <Modal
        footer={null}
        closable={false}
        open={isWarningOpen}
      >
        <h1>Bu ilacı silmek ilacın sahip olduğu bütün satış ve rapor ilişkilerini siler</h1>
        <div>İlacı silmek istediğinize emin misiniz?</div>
        <Button type="primary" danger onClick={() =>  {DeleteIlacFunc(); setIsInfoOpen(true)}}>Sil</Button>
        <Button type="primary" onClick={() => setIsWarningOpen(false)}>Vazgeç</Button>
      </Modal>
      <Modal
        footer={null}
        closable={false}
        open={isInfoOpen}
      >
        <h1>{infoMessage}</h1>
        <Button
          type="primary"
          danger
          onClick={() => {
            setIsInfoOpen(false);
            setIsWarningOpen(false);
            setInfoMessage("");
          }}
        >
          Kapat
        </Button>
      </Modal>
    </>
  );
};

export default Ilac;