import { Button, Modal } from "antd";
import "./SatisButton.css"
import { useState } from "react";
import SatisForm from "./SatisForm";
import SatisOlustur from "../../api/SatisOlustur";

const SatisButton = ({checkedList}) => {
  const [isOpen, setIsOpen] = useState(false);

  const handleSubmit = async (values) => {
    console.log(values)
    await SatisOlustur(values);
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
        closable={false}
        footer={null}
        destroyOnClose
      >
        <SatisForm checkedList={checkedList} setIsOpen={setIsOpen} handleSubmit={handleSubmit}/>
      </Modal>
    </>
  );
}

export default SatisButton;
