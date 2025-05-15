import { Button, Modal } from "antd";
import "./IlacAdd.css";
import { useState } from "react";
import IlacAddForm from "./IlacAddForm";

const IlacAdd = ({ setIlaclar, ilaclar, setCheckedList }) => {
  const [modalOpen, setModalOpen] = useState(false);
  const [resultModalOpen, setResultModalOpen] = useState(false);
  const [message, setMessage] = useState("");

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
        onCancel={() => {
          handleOnClick(false);
        }}
        onOk={() => handleOnClick(false)}
        footer={null}
        closable={false}
        width={400}
        destroyOnClose
      >
        <IlacAddForm
          setModalOpen={setModalOpen}
          setResultModalOpen={setResultModalOpen}
          setMessage={setMessage}
          setIlaclar={setIlaclar}
          ilaclar={ilaclar}
          setCheckedList={setCheckedList}
        />
      </Modal>

      <Modal
        open={resultModalOpen}
        onCancel={() => setResultModalOpen(false)}
        onOk={() => setResultModalOpen(false)}
        footer={null}
        closable={false}
      >
        <h2>{message}</h2>
        <Button
          type="primary"
          onClick={() => setResultModalOpen(false)}
          style={{ marginTop: "10px" }}
        >
          Tamam
        </Button>
      </Modal>
    </>
  );
};

export default IlacAdd;
