import { Button, Modal } from "antd";
import "./SatisButton.css"
import { useState } from "react";
import SatisForm from "./SatisForm";
import SatisOlustur from "../../api/SatisOlustur";


const SatisButton = ({checkedList, satislar, setSatislar}) => {
  const [isOpen, setIsOpen] = useState(false);

  const handleSubmit = async (values) => {
    console.log(values)
    const satis = await SatisOlustur(values);
    setSatislar([...satislar, satis])
  };

  return (
    <>
      <Button 
        type="default" 
        color="orange" 
        variant="solid"
        onClick={() => setIsOpen(true)}
      >
        Satış Oluştur
      </Button>

      <Modal 
        open={isOpen}
        onCancel={() => setIsOpen(false)}
        onOk={() => setIsOpen(false)}
        footer={null}
        closable={false}
        destroyOnClose
      >
        <SatisForm checkedList={checkedList} setIsOpen={setIsOpen} handleSubmit={handleSubmit}/>
      </Modal>
    </>
  );
}

export default SatisButton;
