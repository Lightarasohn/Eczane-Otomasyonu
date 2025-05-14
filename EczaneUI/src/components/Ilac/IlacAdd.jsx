import { Button, Modal } from "antd";
import "./IlacAdd.css";
import { useState } from "react";
import IlacAddForm from "./IlacAddForm";

const IlacAdd = ({setIlaclar, ilaclar}) => {
  const [modalOpen, setModalOpen] = useState(false);
  const [isSuccess, setIsSuccess] = useState(false);

  const handleOnClick = (state) => {
    setModalOpen(state);
  };

  return (
    <>
      <Button
        className="ilac-add-button"
        type="default"
        color="green"
        variant="solid"
        onClick={() => handleOnClick(true)}
      >
        İlac Ekle
      </Button>
      <Modal
        className="modal"
        open={modalOpen}
        onCancel={() => {handleOnClick(false); setIsSuccess(false)}}
        onClose={() => {handleOnClick(false); setIsSuccess(false)}}
        onOk={() => {handleOnClick(false)}}
        okType="default"
        footer={null}
        closable={false}
        width={400}
        style={{justifyContent:"center", alignContent:"center"}}
        destroyOnHidden
      >
        <IlacAddForm
        setModalOpen={setModalOpen} 
        isSuccess={isSuccess} 
        setIsSuccess={setIsSuccess} 
        setIlaclar={setIlaclar}
        ilaclar={ilaclar}></IlacAddForm>
      </Modal>
    </>
  );
};

export default IlacAdd;
