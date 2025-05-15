import { Button, Modal } from "antd";
import "./SatisButton.css"
import { useState } from "react";
import SatisForm from "./SatisForm";
import SatisOlustur from "../../api/SatisOlustur";
import GetIlaclar from "../../api/GetIlaclar";


const SatisButton = ({checkedList, satislar, setSatislar, setIlaclar}) => {
  const [isOpen, setIsOpen] = useState(false);
  const [message, setMessage] = useState("");

  const handleSubmit = async (values) => {
    console.log(values)
    const satis = await SatisOlustur(values);
    if(satis != null){
      setMessage("Satis eklendi");
      setSatislar([...satislar, satis])
      const yeniIlaclar = await GetIlaclar();
      setIlaclar(yeniIlaclar);
    }else{
      setMessage("Satis eklenmedi");
    }
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
        <SatisForm 
        checkedList={checkedList}
        setIsOpen={setIsOpen} 
        handleSubmit={handleSubmit}
        message={message}
        setMessage={setMessage}/>
      </Modal>
    </>
  );
}

export default SatisButton;
