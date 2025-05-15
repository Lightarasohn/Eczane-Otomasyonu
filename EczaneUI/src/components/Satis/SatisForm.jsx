import { InputNumber, Button, Form, Input, Modal } from "antd";
import { useState } from "react";
import "./SatisForm.css";

const SatisForm = ({ checkedList, setIsOpen, handleSubmit, message, setMessage }) => {
  const [miktarData, setMiktarData] = useState({});
  const [isError, setIsError] = useState(false);

  const handleMiktarChange = (value, id) => {
    setMiktarData(prev => ({
      ...prev,
      [id]: value
    }));
  };

  const onFinish = (values) => {
    let isError = false;
    if (checkedList.length === 0) {
      setMessage("Satış için en az 1 ilaç seçilmelidir");
      isError = true;
    }
    checkedList.forEach(ilac => {
      if(miktarData[ilac.id] > ilac.stokDurumu){
        setMessage(`Seçilen ilaç miktarı (${miktarData[ilac.id]}) kadar ilaç stokta yok. İlaç:${ilac.adi} Stok:${ilac.stokDurumu}`)
        isError = true;
        return;
      }
    })

    if(isError){
      setIsError(true);
      return;
    }

    const result = {
      email: values.email,
      ilaclar: checkedList.map(item => ({
        ...item,
        miktar: miktarData[item.id] || 1
      }))
    };

    handleSubmit(result);
    setIsError(true);
  };

  return (
    <>
    <Form layout="vertical" onFinish={onFinish}>
      <h1 style={{ fontSize: "30px" }}>Seçilen ilaçlar</h1>

      {checkedList.map((item) => (
        <div
          key={item.id}
          style={{
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
            marginBottom: "10px"
          }}
        >
          <li style={{ flex: 1 }}>{item.adi}</li>
          <li style={{ flex: 1, textAlign: "right" }}>
            Stok: {item.stokDurumu}
          </li>
          <li style={{ flex: 1, textAlign: "right", paddingRight: "40px" }}>
            Fiyat: {item.fiyati} TL
          </li>
          <li
            style={{
              flex: 1,
              display: "flex",
              justifyContent: "flex-end",
              alignItems: "center",
              gap: "5px"
            }}
          >
            <span>Miktar:</span>
            <InputNumber
              min={0}
              value={miktarData[item.id] || 1}
              onChange={(value) => handleMiktarChange(value, item.id)}
            />
          </li>
        </div>
      ))}

      <Form.Item
        name="email"
        label="Email"
        rules={[
          { required: true, message: "Email girilmelidir" },
          { type: "email", message: "Geçerli bir email girilmelidir" }
        ]}
      >
        <Input placeholder="ornek@eposta.com" />
      </Form.Item>

      <div style={{ display: "flex", justifyContent: "left", gap: "10px" }}>
        <Button type="primary" htmlType="submit">
          Satışı Oluştur
        </Button>
        <Button type="primary" danger onClick={() => setIsOpen(false)}>
          İptal
        </Button>
      </div>
    </Form>
    <Modal footer={null} onCancel={() => setIsError(false)} onClose={() => setIsError(false)}
    onOk={() => setIsError(false)}
    open={isError}>
      <h1>{message}</h1>
      <Button type="primary" danger variant="solid" onClick={() => setIsError(false)}>Tamam</Button>
    </Modal>
    </>
  );
};

export default SatisForm;
